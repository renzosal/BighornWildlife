using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using BighornWildlife.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace BighornWildlife.API.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            Client client = null;

            //Get clientid and secret from either authorization Header or form/url-encoded
            if(!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            //Check to see if the user application set the client info
            if(context.ClientId == null)
            {
                //Remove the comments from the below line context.SetError, and invalidate context 
                //if you want to force sending clientId/secrects once obtain access tokens. 
                //context.Validated();
                context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);

            }

            //check if client info received exists in database
            using (AuthRepository _authRepo = new AuthRepository())
            {
                client = _authRepo.FindClient(context.ClientId);
            }

            if(client == null)
            {
                context.SetError("invalid_clientId", string.Format("{0} is not a valid client id.", context.ClientId));
                return Task.FromResult<object>(null);
            }

            //check if the client is a js app or not to enforce client secret
            if (client.ApplicationType == Models.ApplicationTypes.NativeConfidential)
            {
                if(string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret is required.");
                    return Task.FromResult<object>(null);
                }
                else
                {
                    if (client.Secret != Helper.GetHash(clientSecret))
                    {
                        context.SetError("invalid_clientId", "Client secret is not valid.");
                        return Task.FromResult<object>(null);
                    }
                }
            }

            //check if client is currently active in our database
            if (!client.Active)
            {
                context.SetError("invalid_clientId", "Client is not active.");
                return Task.FromResult<object>(null);
            }

            //set allowed origin and refresh token to OwinContext
            context.OwinContext.Set<string>("as:clientAllowedOrigin", client.AllowedOrigin);
            context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            //validate client
            context.Validated();
            return Task.FromResult<object>(null);
        }

        //Validate resource owner and bind clientId to the access token created
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Set Allowed Origin
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (allowedOrigin == null) ? "*" : allowedOrigin });

            //Check if user is valid
            using (AuthRepository _authRepo = new AuthRepository())
            {
                IdentityUser user = await _authRepo.FindUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The username or password is incorrect.");
                    return;
                }
            }
            // if valid, create a claims identity and add claims
            ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            var properties = new AuthenticationProperties(new Dictionary<string, string> { 
                { "as:client_id", (context.ClientId == null) ? string.Empty : context.ClientId },
                { "userName", context.UserName }
            });

            var authTicket = new AuthenticationTicket(identity, properties);
            context.Validated(authTicket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach(var property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }

            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }
    }
}
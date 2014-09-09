using Microsoft.AspNet.Identity;
using BighornWildlife.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BighornWildlife.API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _authRepo = null;

        public AccountController()
        {
            _authRepo = new AuthRepository();
        }


        //POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _authRepo.RegisterUser(userModel);
            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _authRepo.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Private
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if(!result.Succeeded)
            {
                if(result.Errors != null)
                {
                    foreach(string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    //No ModelState errors are available to send, so just return an empty BadRequest
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
        #endregion
    }

}

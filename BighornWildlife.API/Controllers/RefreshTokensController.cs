using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BighornWildlife.API.Controllers
{
    [RoutePrefix("api/RefreshTokens")]
    public class RefreshTokensController : ApiController
    {
        private AuthRepository _authRepo = null;

        public RefreshTokensController()
        {
            _authRepo = new AuthRepository();
        }

        [Authorize(Users="Admin")]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_authRepo.GetAllRefreshTokens());
        }

        //[Authorize(Users = "Admin")]
        [AllowAnonymous]
        [Route("")]
        public async Task<IHttpActionResult> Delete(string tokenId)
        {
            var result = await _authRepo.RemoveRefreshToken(tokenId);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Token Id does not exist");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _authRepo.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}

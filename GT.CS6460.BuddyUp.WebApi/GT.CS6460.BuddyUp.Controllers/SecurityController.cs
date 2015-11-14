using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Threading.Tasks;
using GT.CS6460.BuddyUp.DomainModel;
using GT.CS6460.BuddyUp.DomainDto;
using GT.CS6460.BuddyUp.Platform.Common;

namespace GT.CS6460.BuddyUp.Controllers
{
    /// <summary>
    /// security controller for Login, Logout and Reset Password
    /// </summary>
    [RoutePrefix("api/security")]
    public class SecurityController : ApiController
    {
        private ISecurity _security;

        public SecurityController(ISecurity security)
        {
            _security = security;
        }

        /// <summary>
        /// Get a Token for rest of the API requests
        /// </summary>
        /// <param name="request">The authentication request containing EmailId and Password.</param>
        /// <returns>Security token information along with other token information</returns>
        [Route("login")]
        [HttpPost]
        [ResponseType(typeof(Token))]
        public HttpResponseMessage Login([FromBody] AuthenticationRequest request)
        {
            if (request == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Reuest data is null");
            Token resp = null;
            try
            {
                resp = _security.Login(request);
                return Request.CreateResponse<Token>(HttpStatusCode.OK, resp);
            }
            catch(DomainModelResponse dmr)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, dmr.FinalMessage);
            }
        }

        /// <summary>
        /// Log out and invalidate the token
        /// </summary>
        /// <param name="token">The token</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [Route("logout")]
        [HttpPost]
        public HttpResponseMessage Logout(string token)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Reset the password for the user
        /// </summary>
        /// <param name="request">Reset password request</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [Route("resetpassword")]
        [HttpPost]
        public HttpResponseMessage ResetPassword([FromBody] ResetPasswordRequest request)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }
    }
}

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
    /// User controller is for user maintenance
    /// </summary>
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public UserController()
        {

        }

        /// <summary>
        /// Add a new user to the system
        /// </summary>
        /// <param name="request">Data of user to be added</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPost]
        public HttpResponseMessage Add(UserAddRequest request)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Update an existing user in the system
        /// </summary>
        /// <param name="request">Data of user to be updated</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPut]
        public HttpResponseMessage Update(UserUpdateRequest request)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Get all users in the system
        /// </summary>
        /// <returns>All the users in the system</returns>
        [ResponseType(typeof(IEnumerable<UserGetResponse>))]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Get specific user from the system
        /// </summary>
        /// <param name="emailId">Email Id of the user to be found</param>
        /// <returns>User details</returns>
        [ResponseType(typeof(UserGetResponse))]
        [HttpGet]
        public HttpResponseMessage GetById(string emailId)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Delete a user from the system
        /// </summary>
        /// <param name="emailId">Email Id of the user to be deleted</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string emailId)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }
    }
}

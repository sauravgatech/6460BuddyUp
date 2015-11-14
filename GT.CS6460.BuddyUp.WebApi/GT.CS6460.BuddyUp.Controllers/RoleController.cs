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
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        public RoleController()
        {

        }
        /// <summary>
        /// Add a new role
        /// </summary>
        /// <param name="request">Role</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPost]
        public HttpResponseMessage Add(Role request)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Update a role
        /// </summary>
        /// <param name="request">Role</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPut]
        public HttpResponseMessage Update(Role request)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns>Roles</returns>
        [ResponseType(typeof(IEnumerable<Role>))]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Get a role
        /// </summary>
        /// <param name="roleCode">role code</param>
        /// <returns>Role</returns>
        [ResponseType(typeof(Role))]
        [HttpGet]
        public HttpResponseMessage Get(string roleCode)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Delete a role
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string roleCode)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }
    }
}

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
    /// Course User Add or Delete support controller
    /// </summary>
    [RoutePrefix("api/courseuser")]
    public class CourseUserController : ApiController
    {
        public CourseUserController()
        {

        }

        /// <summary>
        /// Add a user to course
        /// </summary>
        /// <param name="request">Course and User to add</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPost]
        public HttpResponseMessage Add(CourseUserUpdateRequest request)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Delete a user from course
        /// </summary>
        /// <param name="request">Course and User to delete</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpDelete]
        public HttpResponseMessage Delete(CourseUserUpdateRequest request)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }
    }
}

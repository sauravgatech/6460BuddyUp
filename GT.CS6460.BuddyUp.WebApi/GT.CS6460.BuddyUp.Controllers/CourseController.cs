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
    /// API to get/add/update Course details
    /// </summary>
    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {
        public CourseController()
        {

        }

        /// <summary>
        /// Add a new course
        /// </summary>
        /// <param name="request">Request to add course</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPost]
        public HttpResponseMessage Add(CourseAddRequest request)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Update an existing course
        /// </summary>
        /// <param name="request">Request to update course</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPut]
        public HttpResponseMessage Update(CourseUpdateRequest request)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Get all courses
        /// </summary>
        /// <returns>Course details</returns>
        [ResponseType(typeof(CourseGetResponse))]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Get course by course code
        /// </summary>
        /// <param name="courseCode">Course code</param>
        /// <returns>course details</returns>
        [HttpGet]
        public HttpResponseMessage Get(string courseCode)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Delete a course
        /// </summary>
        /// <param name="courseCode">course code to be deleted</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string courseCode)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }
    }
}

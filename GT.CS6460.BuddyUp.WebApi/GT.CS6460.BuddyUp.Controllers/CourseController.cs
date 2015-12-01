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
        private ICourse _Course;

        public CourseController(ICourse Course)
        {
            _Course = Course;
        }

        /// <summary>
        /// Add a new course
        /// </summary>
        /// <param name="request">Request to add course</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPost]
        public HttpResponseMessage Add([FromBody] CourseAddRequest request)
        {
            try
            {
                DomainModelResponse dmr = _Course.Add(request);
                return Request.CreateResponse(HttpStatusCode.OK, dmr.FinalMessage);
            }
            catch (DomainModelResponse sdmr)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, sdmr.FinalMessage);
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, MessageCodes.ErrInternalServerError.GetDescription() + exp.Message);
            }
        }

        /// <summary>
        /// Update an existing course
        /// </summary>
        /// <param name="request">Request to update course</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPut]
        public HttpResponseMessage Update([FromBody] CourseUpdateRequest request)
        {
            try
            {
                DomainModelResponse dmr = _Course.Update(request);
                return Request.CreateResponse(HttpStatusCode.OK, dmr.FinalMessage);
            }
            catch (DomainModelResponse sdmr)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, sdmr.FinalMessage);
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, MessageCodes.ErrInternalServerError.GetDescription() + exp.Message);
            }
        }

        /// <summary>
        /// Get all courses
        /// </summary>
        /// <returns>Course details</returns>
        [ResponseType(typeof(CourseGetResponse))]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                IEnumerable<CourseGetResponse> response = _Course.Get();
                return Request.CreateResponse<IEnumerable<CourseGetResponse>>(HttpStatusCode.OK, response);
            }
            catch (DomainModelResponse sdmr)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, sdmr.FinalMessage);
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, MessageCodes.ErrInternalServerError.GetDescription() + exp.Message);
            }
        }

        /// <summary>
        /// Get course by course code
        /// </summary>
        /// <param name="courseCode">Course code</param>
        /// <returns>course details</returns>
        [HttpGet]
        public HttpResponseMessage Get(string courseCode)
        {
            try
            {
                IEnumerable<CourseGetResponse> response = _Course.Get(courseCode);
                return Request.CreateResponse<IEnumerable<CourseGetResponse>>(HttpStatusCode.OK, response);
            }
            catch (DomainModelResponse sdmr)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, sdmr.FinalMessage);
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, MessageCodes.ErrInternalServerError.GetDescription() + exp.Message);
            }
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

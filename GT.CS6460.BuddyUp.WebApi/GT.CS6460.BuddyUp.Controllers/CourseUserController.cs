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
    [RoutePrefix("api/courseuser")]
    public class CourseUserController : ApiController
    {
        private ICourseUser _CourseUser;

        public CourseUserController(ICourseUser CourseUser)
        {
            _CourseUser = CourseUser;
        }

        [HttpPut]
        public HttpResponseMessage Update([FromBody] CourseUserUpdateRequest request)
        {
            try
            {
                DomainModelResponse dmr = _CourseUser.UpdateCourseUserAnswer(request);
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
    }
}

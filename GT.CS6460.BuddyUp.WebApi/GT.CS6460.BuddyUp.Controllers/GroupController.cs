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
    [RoutePrefix("api/Group")]
    public class GroupController : ApiController
    {
        IGroup _group;
        public GroupController(IGroup group)
        {
            _group = group;
        }

        /// <summary>
        /// Add a Group
        /// </summary>
        /// <param name="request">Group to add</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPost]
        public HttpResponseMessage Add([FromBody]GroupAddRequest request)
        {
            try
            {
                DomainModelResponse dmr = _group.Add(request);
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
        /// Add a Group
        /// </summary>
        /// <param name="request">Group to update</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPut]
        public HttpResponseMessage Update([FromBody]GroupUpdateRequest request)
        {
            try
            {
                DomainModelResponse dmr = _group.Update(request);
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
        /// Get all Groups
        /// </summary>
        /// <returns>Group details</returns>
        [ResponseType(typeof(IEnumerable<GroupGetResponse>))]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                IEnumerable<GroupGetResponse> response = _group.Get();
                return Request.CreateResponse<IEnumerable<GroupGetResponse>>(HttpStatusCode.OK, response);
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
        /// Get Group by Group Code
        /// </summary>
        /// <param name="courseCode">Group code</param>
        /// <returns>Group details</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<GroupGetResponse>))]
        public HttpResponseMessage Get(string groupCode)
        {
            try
            {
                IEnumerable<GroupGetResponse> response = _group.Get(groupCode);
                return Request.CreateResponse<IEnumerable<GroupGetResponse>>(HttpStatusCode.OK, response);
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

        [HttpGet]
        [ResponseType(typeof(GroupSummaryForUser))]
        public HttpResponseMessage Get(string userEmail, string courseCode)
        {
            try
            {
                GroupSummaryForUser response = _group.GetGroupSummary(userEmail, courseCode);
                return Request.CreateResponse<GroupSummaryForUser>(HttpStatusCode.OK, response);
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
        /// Delete a Group
        /// </summary>
        /// <param name="request">group to delete</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string groupCode)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }
    }
}

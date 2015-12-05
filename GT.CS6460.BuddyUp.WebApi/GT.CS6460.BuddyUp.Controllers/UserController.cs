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
        private IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        /// <summary>
        /// Add a new user to the system
        /// </summary>
        /// <param name="request">Data of user to be added</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPost]
        public HttpResponseMessage Add([FromBody] UserAddRequest request)
        {
            try
            {
                DomainModelResponse dmr = _user.Add(request);
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
        /// Update an existing user in the system
        /// </summary>
        /// <param name="request">Data of user to be updated</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPut]
        public HttpResponseMessage Update([FromBody] UserUpdateRequest request)
        {
            try
            {
                DomainModelResponse dmr = _user.Update(request);
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
        /// Get all users in the system
        /// </summary>
        /// <returns>All the users in the system</returns>
        [ResponseType(typeof(IEnumerable<UserGetResponse>))]
        [HttpGet]
        //[Authorize]
        public HttpResponseMessage GetAll()
        {
            try
            {
                IEnumerable<UserGetResponse> response = _user.Get();
                return Request.CreateResponse<IEnumerable<UserGetResponse>>(HttpStatusCode.OK, response);
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
        /// Get specific user from the system
        /// </summary>
        /// <param name="emailId">Email Id of the user to be found</param>
        /// <returns>User details</returns>
        [ResponseType(typeof(UserGetResponse))]
        [HttpGet]
        public HttpResponseMessage GetById(string emailId)
        {
            try
            {
                IEnumerable<UserGetResponse> response = _user.Get(emailId);
                return Request.CreateResponse<IEnumerable<UserGetResponse>>(HttpStatusCode.OK, response);
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
        /// Delete a user from the system
        /// </summary>
        /// <param name="emailId">Email Id of the user to be deleted</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string emailId)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Add a user to course
        /// </summary>
        /// <param name="request">Request with details of user and course</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [Route("AddUserToCourse")]
        [HttpPost]
        public HttpResponseMessage AddUserToCourse([FromBody] UpdateUserCourse request)
        {
            try
            {
                DomainModelResponse dmr = _user.AddUserToCourse(request);
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
        /// Add a user to Group
        /// </summary>
        /// <param name="request">Request with details of user and group</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [Route("AddUserToGroup")]
        [HttpPost]
        public HttpResponseMessage AddUserToGroup([FromBody] UpdateUserGroup request)
        {
            try
            {
                DomainModelResponse dmr = _user.AddUserToGroup(request);
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
        /// Remove a user From Group
        /// </summary>
        /// <param name="request">Request with details of user and group</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [Route("RemoveUserFromGroup")]
        [HttpPost]
        public HttpResponseMessage RemoveUserFromGroup([FromBody] UpdateUserGroup request)
        {
            try
            {
                DomainModelResponse dmr = _user.RemoveUserFromGroup(request);
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

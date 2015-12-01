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
        private IRole _role;

        public RoleController(IRole role)
        {
            _role = role;
        }
        /// <summary>
        /// Add a new role
        /// </summary>
        /// <param name="request">Role</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPost]
        public HttpResponseMessage Add([FromBody] Role request)
        {
            try
            {
                DomainModelResponse dmr = _role.Add(request);
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
        /// Update a role
        /// </summary>
        /// <param name="request">Role</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPut]
        public HttpResponseMessage Update([FromBody] Role request)
        {
            try
            {
                DomainModelResponse dmr = _role.Update(request);
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
        /// Get all roles
        /// </summary>
        /// <returns>Roles</returns>
        [ResponseType(typeof(IEnumerable<Role>))]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                IEnumerable<DomainDto.Role> response = _role.Get();
                return Request.CreateResponse<IEnumerable<DomainDto.Role>>(HttpStatusCode.OK, response);
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
        /// Get a role
        /// </summary>
        /// <param name="roleCode">role code</param>
        /// <returns>Role</returns>
        [ResponseType(typeof(Role))]
        [HttpGet]
        public HttpResponseMessage Get(string roleCode)
        {
            try
            {
                IEnumerable<DomainDto.Role> response = _role.Get(roleCode);
                return Request.CreateResponse<IEnumerable<DomainDto.Role>>(HttpStatusCode.OK, response);
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

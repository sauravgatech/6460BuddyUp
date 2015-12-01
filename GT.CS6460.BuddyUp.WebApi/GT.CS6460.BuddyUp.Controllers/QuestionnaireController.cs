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
    [RoutePrefix("api/questionnaire")]
    public class QuestionnaireController : ApiController
    {
        IQuestionnaire _Questionnaire;

        public QuestionnaireController(IQuestionnaire Questionnaire)
        {
            _Questionnaire = Questionnaire;
        }

        /// <summary>
        /// Add a Questionnaire
        /// </summary>
        /// <param name="request">Questionnaire</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPost]
        public HttpResponseMessage Add([FromBody]  QuestionnaireAddRequest request)
        {
            try
            {
                DomainModelResponse dmr = _Questionnaire.Add(request);
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
        /// Update Questionnaire
        /// </summary>
        /// <param name="QuestionnaireUpdateRequest">Questionnaire update request</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Update([FromBody]  QuestionnaireUpdateRequest request)
        {
            try
            {
                DomainModelResponse dmr = _Questionnaire.Update(request);
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
        /// Get all Questionnaire
        /// </summary>
        /// <returns>Questionnaires</returns>
        [ResponseType(typeof(IEnumerable<QuestionnaireGetResponse>))]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                IEnumerable<QuestionnaireGetResponse> response = _Questionnaire.Get();
                return Request.CreateResponse<IEnumerable<QuestionnaireGetResponse>>(HttpStatusCode.OK, response);
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
        /// Get a questionnaire
        /// </summary>
        /// <param name="questionnaireCode">Questionnaire code</param>
        /// <returns>Questionnaire</returns>
        [ResponseType(typeof(QuestionnaireAddRequest))]
        [HttpGet]
        public HttpResponseMessage Get(string questionnaireCode)
        {
            try
            {
                IEnumerable<QuestionnaireGetResponse> response = _Questionnaire.Get(questionnaireCode);
                return Request.CreateResponse<IEnumerable<QuestionnaireGetResponse>>(HttpStatusCode.OK, response);
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
        /// Delete a questionnaire
        /// </summary>
        /// <param name="questionnaireCode">questionnaire Code</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string questionnaireCode)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }
    }
}

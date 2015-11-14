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
        public QuestionnaireController()
        {

        }

        /// <summary>
        /// Add a Questionnaire
        /// </summary>
        /// <param name="request">Questionnaire</param>
        /// <returns>HttpResponseMessage stating if the operation was successful.</returns>
        [HttpPost]
        public HttpResponseMessage Add(Questionnaire request)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Add a question to questionnaire
        /// </summary>
        /// <param name="questionnaireCode">Code of Questionnaire</param>
        /// <param name="questionCode">Question Code</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Update(string questionnaireCode, string questionCode)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Get all Questionnaire
        /// </summary>
        /// <returns>Questionnaires</returns>
        [ResponseType(typeof(IEnumerable<Questionnaire>))]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        /// <summary>
        /// Get a questionnaire
        /// </summary>
        /// <param name="questionnaireCode">Questionnaire code</param>
        /// <returns>Questionnaire</returns>
        [ResponseType(typeof(Questionnaire))]
        [HttpGet]
        public HttpResponseMessage Get(string questionnaireCode)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
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

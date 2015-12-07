using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using GT.CS6460.BuddyUp.DomainDto;
using Newtonsoft.Json;

namespace GT.CS6460.BuddyUp.Platform.Communicator
{
    public class QuestionnaireCommunicator
    {
        private APICommunicator apiCom;
        public QuestionnaireCommunicator()
        {
            if (System.Web.Configuration.WebConfigurationManager.AppSettings["APIServer"] != null)
                apiCom = new APICommunicator(System.Web.Configuration.WebConfigurationManager.AppSettings["APIServer"]);
            else
            {
                apiCom = new APICommunicator("http://localhost:1296/");
            }
        }

        public async Task<bool> AddQuestionnaire(QuestionnaireAddRequest request)
        {
            try
            {
                HttpResponseMessage httpResp = apiCom.executePostAPI("Questionnaire", JsonConvert.SerializeObject(request));
                if (httpResp.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<QuestionnaireGetResponse> GetQuestionnaire(string questionnaireCode)
        {
            HttpResponseMessage httpResp = apiCom.executeGetAPI("Questionnaire/" + questionnaireCode);
            if (httpResp.IsSuccessStatusCode)
            {
                string responseBodyAsText = await httpResp.Content.ReadAsStringAsync();
                IEnumerable<QuestionnaireGetResponse> token = JsonConvert.DeserializeObject<IEnumerable<QuestionnaireGetResponse>>(responseBodyAsText);
                return token.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}


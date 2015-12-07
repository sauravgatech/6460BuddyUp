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
    public class SecurityCommmunicator
    {
        private APICommunicator apiCom;
        public SecurityCommmunicator()
        {
            if (System.Web.Configuration.WebConfigurationManager.AppSettings["APIServer"] != null)
                apiCom = new APICommunicator(System.Web.Configuration.WebConfigurationManager.AppSettings["APIServer"]);
            else
            {
                apiCom = new APICommunicator("http://localhost:1296/");
            }
        }

        public async Task<Token> Login(AuthenticationRequest request)
        {

            HttpResponseMessage httpResp = apiCom.executePostAPI("Security/Login", JsonConvert.SerializeObject(request));
            if (httpResp.IsSuccessStatusCode)
            {
                string responseBodyAsText = await httpResp.Content.ReadAsStringAsync();
                Token token = JsonConvert.DeserializeObject<Token>(responseBodyAsText);
                return token;
            }
            else
            {
                return null;
            }
        }
    }
}

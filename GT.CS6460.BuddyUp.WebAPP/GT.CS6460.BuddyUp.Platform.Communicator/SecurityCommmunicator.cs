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
            apiCom = new APICommunicator("https://microsoft-apiapp7a7b49cda6db439fac257467a5b7d0b8.azurewebsites.net");

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

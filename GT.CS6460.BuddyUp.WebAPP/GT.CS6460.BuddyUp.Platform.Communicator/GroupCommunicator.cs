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
    public class GroupCommunicator
    {
        private APICommunicator apiCom;
        public GroupCommunicator()
        {
            apiCom = new APICommunicator("https://microsoft-apiapp7a7b49cda6db439fac257467a5b7d0b8.azurewebsites.net");

        }

        public async Task<GroupSummaryForUser> GetGroupSummary(string userEmail, string courseCode)
        {
            HttpResponseMessage httpResp = apiCom.executeGetAPI("Group/?userEmail=" + userEmail + "&courseCode=" + courseCode);
            if (httpResp.IsSuccessStatusCode)
            {
                string responseBodyAsText = await httpResp.Content.ReadAsStringAsync();
                GroupSummaryForUser token = JsonConvert.DeserializeObject<GroupSummaryForUser>(responseBodyAsText);
                return token;
            }
            else
            {
                return null;
            }
        }

        public async Task<GroupGetResponse> GetGroup(string groupCode)
        {
            HttpResponseMessage httpResp = apiCom.executeGetAPI("Group/" + groupCode);
            if (httpResp.IsSuccessStatusCode)
            {
                string responseBodyAsText = await httpResp.Content.ReadAsStringAsync();
                IEnumerable<GroupGetResponse> token = JsonConvert.DeserializeObject<IEnumerable<GroupGetResponse>>(responseBodyAsText);
                return token.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AddGroup(GroupAddRequest request)
        {
            try
            {
                HttpResponseMessage httpResp = apiCom.executePostAPI("Group", JsonConvert.SerializeObject(request));
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
    }
}

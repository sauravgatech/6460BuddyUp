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
    public class UserCommunicator
    {
        private APICommunicator apiCom;
        public UserCommunicator()
        {
            apiCom = new APICommunicator("https://microsoft-apiapp7a7b49cda6db439fac257467a5b7d0b8.azurewebsites.net");

        }

        public async Task<bool> AddUser(UserAddRequest request)
        {
            try
            {
                HttpResponseMessage httpResp = apiCom.executePostAPI("User", JsonConvert.SerializeObject(request));
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

        public async Task<bool> AddUserToGroup(UpdateUserGroup request)
        {
            try
            {
                HttpResponseMessage httpResp = apiCom.executePostAPI("User/AddUserToGroup", JsonConvert.SerializeObject(request));
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

        public async Task<bool> RemoveUserFromGroup(UpdateUserGroup request)
        {
            try
            {
                HttpResponseMessage httpResp = apiCom.executePostAPI("User/RemoveUserFromGroup", JsonConvert.SerializeObject(request));
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

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
    public class CourseUserCommunicator
    {
        private APICommunicator apiCom;
        public CourseUserCommunicator()
        {
            apiCom = new APICommunicator("https://microsoft-apiapp7a7b49cda6db439fac257467a5b7d0b8.azurewebsites.net");

        }

        public async Task<bool> UpdateCourseUser(CourseUserUpdateRequest request)
        {
            try
            {
                HttpResponseMessage httpResp = apiCom.executePutAPI("CourseUser", JsonConvert.SerializeObject(request));
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

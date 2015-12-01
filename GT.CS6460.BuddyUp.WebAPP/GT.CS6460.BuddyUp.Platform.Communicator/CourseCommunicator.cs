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
    public class CourseCommunicator
    {
        private APICommunicator apiCom;
        public CourseCommunicator()
        {
            apiCom = new APICommunicator("localhost:1296");

        }

        public async Task<bool> AddCourse(CourseAddRequest request)
        {
            try
            {
                HttpResponseMessage httpResp = apiCom.executePostAPI("Course", JsonConvert.SerializeObject(request));
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


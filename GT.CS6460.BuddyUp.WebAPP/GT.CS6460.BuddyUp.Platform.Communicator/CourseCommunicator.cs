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
            apiCom = new APICommunicator("https://microsoft-apiapp7a7b49cda6db439fac257467a5b7d0b8.azurewebsites.net");

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

        public async Task<bool> UpdateCourse(CourseUpdateRequest request)
        {
            try
            {
                HttpResponseMessage httpResp = apiCom.executePutAPI("Course", JsonConvert.SerializeObject(request));
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

        public async Task<CourseGetResponse> GetCourse(string courseCode)
        {
            HttpResponseMessage httpResp = apiCom.executeGetAPI("Course/" + courseCode);
            if (httpResp.IsSuccessStatusCode)
            {
                string responseBodyAsText = await httpResp.Content.ReadAsStringAsync();
                IEnumerable<CourseGetResponse> token = JsonConvert.DeserializeObject<IEnumerable<CourseGetResponse>>(responseBodyAsText);
                return token.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<CourseGetResponse>> GetAllCourses()
        {
            HttpResponseMessage httpResp = apiCom.executeGetAPI("Course");
            if (httpResp.IsSuccessStatusCode)
            {
                string responseBodyAsText = await httpResp.Content.ReadAsStringAsync();
                IEnumerable<CourseGetResponse> token = JsonConvert.DeserializeObject<IEnumerable<CourseGetResponse>>(responseBodyAsText);
                return token;
            }
            else
            {
                return null;
            }
        }
    }
}


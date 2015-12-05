using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GT.CS6460.BuddyUp.Platform.Communicator
{
    public class APICommunicator
    {
        private string _baseAddress = null;
        private string _token = null;
        private string _contentType = null;

        public APICommunicator(string serverAddress, string contentType = "application/json")
        {
            _baseAddress = serverAddress + "/api/";
            _contentType = contentType;
        }

        public HttpResponseMessage executePostAPI(string APIName, string jsonRequest)
        {
            try
            {
                HttpClient client = new HttpClient();
                var content = new StringContent(jsonRequest, Encoding.UTF8, _contentType);
                HttpResponseMessage response = client.PostAsync(_baseAddress + APIName, content).Result;
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public HttpResponseMessage executePutAPI(string APIName, string jsonRequest)
        {
            try
            {
                HttpClient client = new HttpClient();
                var content = new StringContent(jsonRequest, Encoding.UTF8, _contentType);
                HttpResponseMessage response = client.PutAsync(_baseAddress + APIName, content).Result;
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public HttpResponseMessage executeGetAPI(string APIName, Dictionary<string, string> parameters = null)
        {
            try
            {
                HttpClient client = new HttpClient();
                StringBuilder apiStr = new StringBuilder();
                apiStr.Append(APIName);
                if (parameters != null && parameters.Count > 0)
                {
                    apiStr.Append("?");
                    foreach (string key in parameters.Keys)
                        apiStr.Append(key + "=" + parameters[key] + "&");
                    apiStr.Remove(apiStr.Length - 1, 1);
                }
                HttpResponseMessage response = client.GetAsync(_baseAddress + apiStr).Result;
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace ServisInfo_PCL.Util
{
    public class WebAPIHelper
    {
        private HttpClient client { get; set; }
        private string route { get; set; }

        public WebAPIHelper(string uri, string route)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            this.route = route;

        }
        public HttpResponseMessage GetResponse(string parameter = "")
        {
            return client.GetAsync(route + "/" + parameter).Result;
        }

        public HttpResponseMessage GetActionResponse(string action, string parameter = "")
        {
            return client.GetAsync(route + "/" + action + "/" + parameter).Result;
        }

        public HttpResponseMessage GetActionResponse(string action, string parameter = "", string parameter2 = "")
        {
            return client.GetAsync(route + "/" + action + "/" + parameter+ "/" +  parameter2).Result;
        }

        public HttpResponseMessage PostResponse(Object newObject)
        {
            StringContent jsonObject = new StringContent(JsonConvert.SerializeObject(newObject),
                Encoding.UTF8, "application/json");
            return client.PostAsync(route, jsonObject).Result;
        }

        public HttpResponseMessage PutResponse(int id, Object existingObject)
        {
            throw new NotImplementedException();

            // return client.PutAsJsonAsync(route + "/" + id, existingObject).Result;
        }
    }
}

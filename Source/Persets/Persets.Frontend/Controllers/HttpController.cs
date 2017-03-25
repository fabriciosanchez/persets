using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Persets.Frontend.Controllers
{
    public class HttpController
    {
        public static HttpClient client = new HttpClient();

        public static void Initialize()
        {
            client.BaseAddress = new Uri("http://localhost:25241/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
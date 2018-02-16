using System.Net;
using System.Net.Http;
using System.Text;

namespace MovieApp.Helpers
{
    public static class ResponseHelper
    {
        public static HttpResponseMessage FormatMessage(string json, HttpStatusCode statusCode)
        {
            var message = new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            message.Headers.Add("Access-Control-Allow-Origin", "*");
            return message;
        }
    }
}
using A.FreshDesk.ApiClient.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Text;

namespace A.FreshDesk.ApiClient
{
    internal class ApiClient
    {
        private readonly string _apiKey;
        private readonly Uri _domain;

        public ApiClient(string apiKey, string domain)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            _apiKey = apiKey;
            _domain = new Uri(domain);
        }

        public IRestResponse ExecuteRequest(string apiUrl, Method method, object requestBody = null)
        {
            var url = GetUrl(apiUrl);
            var client = new RestClient(url);
            var result = client.Execute(GetRequest(method, requestBody));

            return HandleResponse(result);

        }

        private RestRequest GetRequest(Method method, object requestBody = null)
        {
            var restRequest = new RestRequest(method);
            restRequest.AddHeader("cache-control", "no-cache");
            restRequest.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(_apiKey + ":X")));

            if (requestBody == null) return restRequest;

            var json = JsonConvert.SerializeObject(requestBody);
            restRequest.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

            return restRequest;
        }

        private static IRestResponse HandleResponse(IRestResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest: //400
                case HttpStatusCode.Forbidden: //403
                case HttpStatusCode.NotFound: //404
                case HttpStatusCode.MethodNotAllowed: //405
                case HttpStatusCode.NotAcceptable: //406
                case HttpStatusCode.Conflict: //409
                case HttpStatusCode.UnsupportedMediaType: //415
                case HttpStatusCode.InternalServerError: //500
                    ThrowException(response);
                    break;
            }

            return response;
        }

        private static void ThrowException(IRestResponse response)
        {
            var errorResponse = JsonConvert.DeserializeObject<Errors>(response.Content);
            var errorText = new StringBuilder($"{response.StatusCode.ToString()} -> {errorResponse.Description} {errorResponse.Message}");
            foreach (var error in errorResponse.ErrorList)
            {
                errorText.Append($" | {error.Field} : {error.Message}");
            }
            throw new Exception(errorText.ToString());
        }

        private string GetUrl(string apiUrl)
        {

            var url = string.Format("{0}/{1}", _domain.AbsoluteUri, apiUrl)
                .Replace("https://", "")
                .Replace("http://", "")
                .Replace("//", "/");

            return string.Format("{0}://{1}", _domain.Scheme, url);
        }
    }
}

﻿using DemoAPI_Utility;
using DemoAPI_Web.Models;
using DemoAPI_Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace DemoAPI_Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory _httpClient)
        {
            this.responseModel = new();
            this.httpClient = _httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest aPIRequest)
        {
            try
            {
                var client = httpClient.CreateClient("DemoAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(aPIRequest.Url);
                if (aPIRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(aPIRequest.Data), Encoding.UTF8, "application/json");
                }
                switch(aPIRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = null;
                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch(Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessage = new List<string>()
                    {
                        Convert.ToString(ex.Message)

                    },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }
    }
}

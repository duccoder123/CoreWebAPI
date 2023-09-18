using DemoAPI_Utility;
using DemoAPI_Web.Models;
using DemoAPI_Web.Models.Dto;
using DemoAPI_Web.Services.IServices;

namespace DemoAPI_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory _httpClient;
        private string ApiUrl;
        public VillaService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            ApiUrl = configuration.GetValue<string>("ServiceUrls:DemoAPI");
        }
        public Task<T> CreateAsync<T>(VillaCreateDTO entity, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = entity,
                Url = ApiUrl + $"/api/{SD.CurrentAPIVersion}/VillaAPI",
                Token = token,
                ContentType = SD.ContentType.MultipartFormData
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = ApiUrl + $"/api/{SD.CurrentAPIVersion}/VillaAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = ApiUrl + $"/api/{SD.CurrentAPIVersion}/VillaAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = ApiUrl + $"/api/{SD.CurrentAPIVersion}/VillaAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO entity, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = entity,
                Url = ApiUrl + $"/api/{SD.CurrentAPIVersion}/VillaAPI/" + entity.Id,
                Token = token,
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}

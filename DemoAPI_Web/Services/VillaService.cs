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
        public Task<T> CreateAsync<T>(VillaCreateDTO entity)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = entity,
                Url = ApiUrl + "/api/VillaAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = ApiUrl + "/api/VillaAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = ApiUrl + "/api/VillaAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = ApiUrl + "/api/VillaAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO entity)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = entity,
                Url = ApiUrl + "/api/VillaAPI/" + entity.Id
            });
        }
    }
}

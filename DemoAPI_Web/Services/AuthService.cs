using DemoAPI_Utility;
using DemoAPI_Web.Models;
using DemoAPI_Web.Models.Dto;
using DemoAPI_Web.Services.IServices;

namespace DemoAPI_Web.Services
{
    public class AuthService : BaseService,IAuthService
    {
        private readonly IHttpClientFactory _httpClient;
        private string villaUrl;
        public AuthService(IHttpClientFactory httpClient, IConfiguration configuration ) : base(httpClient)
        {
            _httpClient = httpClient;
            villaUrl = configuration.GetValue<string>("ServiceUrls:Secret");
        }

        public Task<T> LoginAsync<T>(LoginRequestDTO objTocreate)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = objTocreate,
                Url = villaUrl + "/api/UserAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegisterationRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = villaUrl + "/api/UserAuth/register"
            });
        }
    }
}

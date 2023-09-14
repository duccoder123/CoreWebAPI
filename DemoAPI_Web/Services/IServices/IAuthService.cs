using DemoAPI_Web.Models.Dto;

namespace DemoAPI_Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO objTocreate);
        Task<T>  RegisterAsync<T>(RegisterationRequestDTO objTocreate);
    }
}

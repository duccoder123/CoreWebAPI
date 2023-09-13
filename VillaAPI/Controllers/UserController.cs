using Microsoft.AspNetCore.Mvc;

namespace VillaAPI.Controllers
{
    [Route("api/UsersAuth")]
    [ApiController]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

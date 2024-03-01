using Auth.API.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Login(string userName, string password)
        {
            return Ok(userName == "emreaknci" && password == "123456" ? TokenHandler.CreateAccessToken(_configuration) : new UnauthorizedResult());
        }
    }
}

using APICSHARP.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace APICSHARP.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "joao" && password == "123")
            {
                var token = TokenService.GenerateToken(new Domain.Model.EmployeeAggregate.Employee());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}

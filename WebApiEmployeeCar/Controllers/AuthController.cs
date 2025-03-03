using Microsoft.AspNetCore.Mvc;
using WebApiEmployeeCar.Models;

namespace WebApiEmployeeCar.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        // Replace this with your actual authentication logic
        if (loginDto.Email == "admin@gmail.com" && loginDto.Password == "admin")
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("UserId", "123");
            session.SetString("UserEmail", loginDto.Email);

            return Ok(new { id = "123", name = "Test User", email = loginDto.Email });
        }

        return Unauthorized();
    }

    [HttpGet("session")]
    public IActionResult GetSession()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var userId = session.GetString("UserId");

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        return Ok(new { id = userId, email = session.GetString("UserEmail") });
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        _httpContextAccessor.HttpContext.Session.Clear();
        return Ok();
    }
}
using Dsw2025Ej15.Application.Dtos;
using Dsw2025Ej15.Application.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2025Ej15.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticateController : ControllerBase
{
    private readonly JwtTokenService _jwtTokenService;

    public AuthenticateController(JwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel request)
    {
        // Aquí deberías validar el usuario y contraseña contra tu base de datos o sistema de usuarios
        if (request.Username == "admin" && request.Password == "123456") // Ejemplo simple
        {
            var token = _jwtTokenService.GenerateToken(request.Username, "tester");
            return Ok(new { token });
        }
        return Unauthorized();
    }
}

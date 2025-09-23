
using Api.Models.DTOs;
using Api.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IAuthService _authService;

  public AuthController(IAuthService authService)
  {
    _authService = authService;
  }

  [HttpPost("login")]
  public IActionResult Login([FromBody] LoginRequestDTO request)
  {
    return Ok(_authService.Login(request));
  }

}

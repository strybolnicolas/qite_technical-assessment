
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Config;
using Api.Models.Classes;
using Api.Models.DTOs;
using Api.Models.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services;

public class AuthService : IAuthService
{
  private readonly JwtSettings _jwtSettings;
  private readonly IUserRepository _userRepository;

  public AuthService(IOptions<JwtSettings> jwtSettings, IUserRepository userRepository)
  {
    _jwtSettings = jwtSettings.Value;
    _userRepository = userRepository;
  }

  public async Task<LoginResponseDTO?> Login(LoginRequestDTO request)
  {
    User? user = await _userRepository.GetByUsername(request.Username);

    if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
    {
      return null;
    }

    return new LoginResponseDTO
    {
      Success = true,
      Token = GenerateToken(user),
      Username = user.Username,
      Role = user.Role
    };
  }

  public string GenerateToken(User user)
  {
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

    var token = new JwtSecurityToken(
        issuer: _jwtSettings.Issuer,
        audience: _jwtSettings.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
        signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }

  public string GetSecret()
  {
    return _jwtSettings.Secret;
  }

  // Private Methods
  private bool VerifyPassword(string plainPassword, string hashedPassword)
  {
    return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
  }

}

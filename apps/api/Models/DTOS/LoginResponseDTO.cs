

namespace Api.Models.DTOs;

public class LoginResponseDTO
{
  public bool Success { get; set; }
  public string? Message { get; set; }
  public string? Username { get; set; }
  public string? Role { get; set; }
  public string? Token { get; set; }
}

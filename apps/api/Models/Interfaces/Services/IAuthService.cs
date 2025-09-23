
using Api.Models.DTOs;

namespace Api.Models.Interfaces;

public interface IAuthService
{
  Task<LoginResponseDTO?> Login(LoginRequestDTO request);
}


using Api.Models.Classes;

namespace Api.Models.Interfaces;

public interface IUserRepository
{
  Task<User?> GetByUsername(string username);
}

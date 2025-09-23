
using Api.Data;
using Api.Models.Classes;
using Api.Models.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Api.Repositories;

public class UserRepository : IUserRepository
{
  private readonly ApiDbContext _context;

  public UserRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<User?> GetByUsername(string username)
  {
    return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
  }
}

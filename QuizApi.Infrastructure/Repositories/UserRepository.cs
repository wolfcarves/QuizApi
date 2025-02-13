using Microsoft.EntityFrameworkCore;
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Core.Entities;
using QuizApi.Infrastructure.Persistence;

namespace QuizApi.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) => _context = context;

    public Task<User?> FindOneById(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> FindOneByUsername(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Username == username);
    }
}
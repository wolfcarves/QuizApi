
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Application.Interfaces.Services;
using QuizApi.Core.Entities;
using QuizApi.Core.Exceptions;

namespace QuizApi.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    public AuthService(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<User> LoginUserAsync(string username, string password)
    {
        var user = await _userRepository.FindOneByUsername(username);

        if (user == null)
            throw new UnauthorizedException("Username or password is incorrect");

        return user;
    }
}
using QuizApi.Application.Interfaces.Services;
using QuizApi.Core.Entities;
using QuizApi.Core.Exceptions;

namespace QuizApi.Application.Services;

public class AuthService : IAuthService
{
    public AuthService() { }

    public async Task<User> LoginUserAsync(string username, string password)
    {
        // var user = await _userRepository.FindOneByUsername(username);
        var user = new User
        {
            Firstname = "Rodel",
            Lastname = "Crisosto",
            Username = "Cazcade"
        };

        if (user == null)
            throw new UnauthorizedException("Username or password is incorrect");

        return user;
    }
}
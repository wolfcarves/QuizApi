using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Application.Interfaces.Services;
using QuizApi.Core.Entities;
using QuizApi.Core.Exceptions;

namespace QuizApi.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<User> GetUserAsync(string username)
    {
        var user = await _userRepository.FindOneByUsername(username);

        if (user == null) throw new NotFoundException("User not found");

        return user;
    }
}
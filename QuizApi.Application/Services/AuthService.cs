using AutoMapper;
using FluentValidation;
using QuizApi.Application.DTO.User;
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Application.Interfaces.Services;
using QuizApi.Application.Validators.User;
using QuizApi.Core.Entities;
using QuizApi.Core.Exceptions;

namespace QuizApi.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public AuthService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<User> LoginUserAsync(UserLoginDTO requestBody)
    {
        string username = requestBody.Username;

        var user = await _userRepository.FindOneByUsername(username);

        if (user == null)
            throw new UnauthorizedException("Username or password is incorrect");

        return user;
    }

    public async Task<UserDTO> SignUpAsync(UserSignUpDTO requestBody)
    {
        UserSignupValidator validator = new UserSignupValidator();
        await validator.ValidateAndThrowAsync(requestBody);

        string username = requestBody.Username;
        string password = requestBody.Password;

        var existingUser = await _userRepository.FindOneByUsername(username);
        if (existingUser != null) throw new ConflictException("Username already taken.");

        var user = _mapper.Map<User>(requestBody);

        string hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
        user.Password = hashPassword;

        await _userRepository.PostUser(user);

        return _mapper.Map<UserDTO>(user);
    }
}
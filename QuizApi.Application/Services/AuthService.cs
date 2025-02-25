using System.Security.Claims;
using AutoMapper;
using BCrypt.Net;
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
    private readonly IJwtTokenService _jwtService;
    private readonly IMapper _mapper;

    public AuthService(IUserRepository userRepository, IJwtTokenService jwtService, IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _mapper = mapper;
    }

    public async Task<(User user, string accessToken, string refreshToken)> LoginUserAsync(UserLoginDTO requestBody)
    {
        string username = requestBody.Username;
        string password = requestBody.Password;

        var user = await _userRepository.FindOneByUsername(username);

        if (user == null)
            throw new UnauthorizedException("Username or password is incorrect");

        bool isPasswordMatched = BCrypt.Net.BCrypt.Verify(password, user.Password);

        if (!isPasswordMatched) throw new UnauthorizedException("Username or password is incorrect");

        var accessToken = _jwtService.GenerateAccessToken($"{user.Id}", user.Username);
        var refreshToken = _jwtService.GenerateRefreshToken();

        return (user, accessToken, refreshToken);
    }

    public async Task<UserDTO> SignupUserAsync(UserSignUpDTO requestBody)
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

    public async Task<UserDTO> GetUserSessionAsync(string? accessToken)
    {
        if (string.IsNullOrWhiteSpace(accessToken))
            throw new UnauthorizedException("Unauthorized");

        var tokenString = accessToken.Replace("Bearer ", "").Trim();

        var claimsPrincipal = _jwtService.ValidateAccessToken(tokenString);
        if (claimsPrincipal == null)
            throw new UnauthorizedException("Unauthorized");

        var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            throw new UnauthorizedException("Unauthorized");

        var user = await _userRepository.FindOneById(Convert.ToInt32(userId));
        if (user == null)
            throw new UnauthorizedException("Unauthorized");

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> DeleteUserSessionAsync(int userId)
    {
        var user = await _userRepository.FindOneById(userId);
        var userDto = _mapper.Map<UserDTO>(user);

        return userDto;
    }

    public async Task<string> GetNewAccessTokenAsync(string? userId, string? username, string? refreshToken)
    {
        if (userId == null || username == null) throw new UnauthorizedException("Unauthorized");

        if (refreshToken == null) throw new UnauthorizedException("No refresh token");

        bool isRefreshTokenValid = _jwtService.ValidateRefreshToken(refreshToken);

        if (!isRefreshTokenValid) throw new UnauthorizedException("Token expired");

        string accessToken = _jwtService.GenerateAccessToken(userId, username);

        return accessToken;
    }
}
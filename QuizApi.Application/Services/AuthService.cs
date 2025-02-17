using System.IdentityModel.Tokens.Jwt;
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
    private readonly IJwtTokenService _jwtService;
    private readonly IMapper _mapper;
    public AuthService(IUserRepository userRepository, IJwtTokenService jwtService, IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _mapper = mapper;
    }

    public async Task<(string accessToken, string refreshToken)> LoginUserAsync(UserLoginDTO requestBody)
    {
        string username = requestBody.Username;

        var user = await _userRepository.FindOneByUsername(username);

        if (user == null)
            throw new UnauthorizedException("Username or password is incorrect");

        var accessToken = _jwtService.GenerateAccessToken($"{user.Id}", user.Username, "user");
        var refreshToken = _jwtService.GenerateRefreshToken();

        return (accessToken, refreshToken);
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

    public async Task<UserDTO> GetUserSessionAsync(string? accessToken)
    {
        if (accessToken == null) throw new UnauthorizedException("Unauthorized");

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(accessToken);

        var authorization = accessToken.ToString().Replace("Bearer ", "");
        var isValid = _jwtService.ValidateAccessToken(authorization);

        var userId = jwtToken?.Claims?.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
        if (!isValid || userId == null) throw new UnauthorizedException("Unauthorized");

        var user = await _userRepository.FindOneById(Convert.ToInt32(userId));

        return _mapper.Map<UserDTO>(user);
    }
}

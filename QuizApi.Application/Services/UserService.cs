using AutoMapper;
using QuizApi.Application.DTO.User;
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Application.Interfaces.Services;
using QuizApi.Core.Entities;
using QuizApi.Core.Exceptions;

namespace QuizApi.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDTO?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.FindOneById(id);

        if (user == null) throw new NotFoundException("User not found");

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO?> GetUserByUsernameAsync(string username)
    {
        var user = await _userRepository.FindOneByUsername(username);

        if (user == null) throw new NotFoundException("User not found");

        return _mapper.Map<UserDTO>(user);
    }
}
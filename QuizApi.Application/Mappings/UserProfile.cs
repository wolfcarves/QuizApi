using AutoMapper;
using QuizApi.Application.DTO.User;
using QuizApi.Core.Entities;

namespace QuizApi.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserSignUpDTO, User>();
        CreateMap<UserDTO, User>();
        CreateMap<User, UserDTO>();
        CreateMap<UserSignUpDTO, UserDTO>();
    }
}
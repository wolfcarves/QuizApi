using AutoMapper;
using QuizApi.Core.Entities;
using QuizApi.WebApi.Application.DTO.Quiz;

namespace QuizApi.Application.Mappings;

public class QuizProfile : Profile
{
    public QuizProfile()
    {
        CreateMap<QuizCreateDTO, Quiz>();
        CreateMap<Quiz, QuizDTO>();
    }
}
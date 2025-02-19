using AutoMapper;
using QuizApi.Core.Entities;
using QuizApi.WebApi.Application.DTO.Question;

namespace QuizApi.Application.Mappings;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<QuestionCreateDTO, Question>();
        CreateMap<Question, QuestionDTO>();
    }
}
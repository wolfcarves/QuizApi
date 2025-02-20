using AutoMapper;
using QuizApi.Core.Entities;
using QuizApi.WebApi.Application.DTO.Question;

namespace QuizApi.Application.Mappings;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<QuestionCreateDTO, Question>()
            .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices));
        CreateMap<Question, QuestionDTO>();
    }
}
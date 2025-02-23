using AutoMapper;
using QuizApi.Core.Entities;
using QuizApi.WebApi.Application.DTO.Choice;

namespace QuizApi.Application.Mappings;

public class ChoiceProfile : Profile
{
    public ChoiceProfile()
    {
        CreateMap<ChoiceCreateDTO, Choice>();
        CreateMap<ChoiceDTO, Choice>();
        CreateMap<Choice, ChoiceDTO>();

    }
}
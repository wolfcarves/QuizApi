using QuizApi.WebApi.Application.DTO.Choice;

namespace QuizApi.WebApi.Application.DTO.Question;

public class QuestionCreateDTO
{
    public string Text { get; set; } = null!;
    public List<ChoiceCreateDTO> Choices { get; set; } = null!;
}
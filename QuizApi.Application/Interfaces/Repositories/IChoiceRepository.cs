using QuizApi.Core.Entities;

namespace QuizApi.Application.Interfaces.Repositories;

public interface IChoiceRepository
{
    Task<IEnumerable<Choice>> CreateRange(IEnumerable<Choice> choice);
}
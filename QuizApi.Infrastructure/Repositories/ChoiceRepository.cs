using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Core.Entities;
using QuizApi.Infrastructure.Persistence;

namespace QuizApi.Infrastructure.Repositories;

public class ChoiceRepository : IChoiceRepository
{
    private readonly AppDbContext _context;
    public ChoiceRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Choice>> CreateRange(IEnumerable<Choice> choice)
    {
        await _context.Choices.AddRangeAsync(choice);
        await _context.SaveChangesAsync();

        return choice;
    }
}

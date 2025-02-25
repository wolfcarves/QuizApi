using Microsoft.EntityFrameworkCore;
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Core.Entities;
using QuizApi.Infrastructure.Persistence;

namespace QuizApi.Infrastructure.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly AppDbContext _context;
    public QuestionRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Question>> Create(IEnumerable<Question> questions)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            foreach (var question in questions)
            {
                foreach (var choice in question.Choices)
                {
                    choice.Id = 0;
                }
            }

            await _context.Questions.AddRangeAsync(questions);
            await _context.SaveChangesAsync(); // Ensure questions get IDs

            foreach (var question in questions)
            {
                var correctChoice = question.Choices.FirstOrDefault(c => c.Is_Correct);
                if (correctChoice != null)
                {
                    question.AnswerId = correctChoice.Id;
                }
            }

            _context.Questions.UpdateRange(questions);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            return questions;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }


    public async Task<IEnumerable<Question>> FindAll(int quizId)
    {
        return await _context.Questions.Where(q => q.QuizId == quizId).Include(q => q.Choices).ToListAsync();
    }
}

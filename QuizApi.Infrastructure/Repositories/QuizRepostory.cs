using Microsoft.EntityFrameworkCore;
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Core.Entities;
using QuizApi.Infrastructure.Persistence;

namespace QuizApi.Infrastructure.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly AppDbContext _context;
    public QuizRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Quiz>> FindAll()
    {
        var quizzes = await _context.Quizzes.Include(q => q.User).ToListAsync();
        return quizzes;
    }

    public async Task<Quiz> Create(Quiz quiz)
    {
        _context.Quizzes.Add(quiz);
        await _context.SaveChangesAsync();
        return quiz;
    }
}

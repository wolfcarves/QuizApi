using Microsoft.EntityFrameworkCore;
using QuizApi.Core.Entities;

namespace QuizApi.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quiz>()
            .HasOne(q => q.Admin)
            .WithMany(q => q.Quizzes)
            .HasForeignKey(q => q.AdminId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
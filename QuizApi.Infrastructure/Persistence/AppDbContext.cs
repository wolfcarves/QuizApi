using Microsoft.EntityFrameworkCore;
using QuizApi.Core.Entities;

namespace QuizApi.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { }

    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quiz>()
            .HasOne(q => q.User)
            .WithMany(q => q.Quizzes)
            .HasForeignKey(q => q.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        AddTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }


    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
                                    .Where(e => e.Entity is BaseEntity
                                    && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entity in entities)
        {
            var now = DateTime.Now;
            var baseEntity = entity.Entity as BaseEntity;

            if (entity.State == EntityState.Added)
            {
                if (baseEntity != null) baseEntity.CreatedAt = now;
            }

            if (baseEntity != null)
                baseEntity.UpdatedAt = now;
        }
    }
}
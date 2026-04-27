using Microsoft.EntityFrameworkCore;
using NetQuestions.Entity.Questions;

namespace NetQuestion.Infrastructure.Postgres;

public class QuestionsDbContext : DbContext
{
    public DbSet<Question> Questions { get; set; }
}

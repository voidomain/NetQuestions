using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetQuestion.Infrastructure.Postgres.Repositories;
using NetQuestions.Application.Database;
using NetQuestions.Application.Questions;

namespace NetQuestion.Infrastructure.Postgres;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<QuestionsDbContext>();
        services.AddScoped<IQuestionsRepository, QuestionsEfCoreRepository>();
        
        return services;
    }
}
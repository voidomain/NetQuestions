using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetQuestions.Application.Questions;

namespace NetQuestions.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddScoped<IQuestionsService, QuestionsService>();

        return services;
    }
}
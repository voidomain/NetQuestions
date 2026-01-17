using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetQuestions.Application.Questions;

namespace NetQuestions.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services) =>
        services.AddWebDependencies()
            .AddApplication();

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }
}
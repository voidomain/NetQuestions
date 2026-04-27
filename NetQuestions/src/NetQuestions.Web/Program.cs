using NetQuestion.Infrastructure.ElasticSearch;
using NetQuestions;
using NetQuestions.Application.FullTextSearch;
using NetQuestions.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProgramDependencies();

builder.Services.AddScoped<ISearchProvider, ElasticSearchProvider>();

var app = builder.Build();

app.UseExceptionMiddleware();

app.UseExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "NetQuestions"));
}

app.MapControllers();

app.Run();
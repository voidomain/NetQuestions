using NetQuestions.Application.FullTextSearch;
using NetQuestions.Entity.Questions;

namespace NetQuestion.Infrastructure.ElasticSearch;

public class ElasticSearchProvider : ISearchProvider
{
    public Task<List<Guid>> SearchAsync(string query) => throw new NotImplementedException();

    public Task IndexQuestionAsync(Question question) => throw new NotImplementedException();
}
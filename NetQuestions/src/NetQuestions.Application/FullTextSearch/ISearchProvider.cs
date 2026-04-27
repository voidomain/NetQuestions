using NetQuestions.Entity.Questions;

namespace NetQuestions.Application.FullTextSearch;

public interface ISearchProvider
{
    Task<List<Guid>> SearchAsync(string query);

    Task IndexQuestionAsync(Question question);
}
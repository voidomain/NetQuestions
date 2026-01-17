namespace NetQuestion.Contracts.Questions;

public record GetQuestionsDto(string Title, Guid[] TagIds, int Page, int PageSize);
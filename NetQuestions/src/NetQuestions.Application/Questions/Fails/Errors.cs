using Shared;

namespace NetQuestions.Application.Questions.Fails;

public partial class Errors
{
    public static class Question
    {
        public static Error ToManyQuestions() =>
            Error.Failure("question.too.many", "Пользователь не может открыть больше 3 вопросов.");
    }
}
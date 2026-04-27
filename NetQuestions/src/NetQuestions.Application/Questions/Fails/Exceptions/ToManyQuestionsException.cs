using NetQuestions.Application.Exceptions;
using Shared;

namespace NetQuestions.Application.Questions.Fails.Exceptions;

public class ToManyQuestionsException : BadRequestException
{
    public ToManyQuestionsException() 
        : base([Errors.Question.ToManyQuestions()])
    {
    }
}
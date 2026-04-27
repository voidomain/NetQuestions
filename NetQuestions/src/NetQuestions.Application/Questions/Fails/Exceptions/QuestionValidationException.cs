using NetQuestions.Application.Exceptions;
using Shared;

namespace NetQuestions.Application.Questions.Fails.Exceptions;

public class QuestionValidationException : BadRequestException
{
    public QuestionValidationException(Error[] errors) 
        : base(errors)
    {
    }
}
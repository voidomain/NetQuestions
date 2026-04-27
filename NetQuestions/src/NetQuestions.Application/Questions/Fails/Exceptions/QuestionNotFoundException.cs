using NetQuestions.Application.Exceptions;
using Shared;

namespace NetQuestions.Application.Questions.Exceptions;

public class QuestionNotFoundException : NotFoundException
{
    protected QuestionNotFoundException(Error[] errors) 
        : base(errors)
    {
    }
}
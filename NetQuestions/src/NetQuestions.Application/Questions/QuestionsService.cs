using FluentValidation;
using Microsoft.Extensions.Logging;
using NetQuestion.Contracts;
using NetQuestion.Contracts.Questions;
using NetQuestions.Entity.Questions;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace NetQuestions.Application.Questions;

public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository _questionsRepository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;

    public QuestionsService(
        IQuestionsRepository questionsRepository, 
        IValidator<CreateQuestionDto> validator,
        ILogger<QuestionsService> logger)
    {
        _questionsRepository = questionsRepository;
        _logger = logger;
        _validator = validator;
    }

    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }
        
        int openUserQuestionsCount = await _questionsRepository
            .GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);
        
        var questionId = Guid.NewGuid();

        var question = new Question(
            questionId,
            questionDto.Title,
            questionDto.Text,
            questionDto.UserId,
            null,
            questionDto.TagIds);

        await _questionsRepository.AddAsync(question, cancellationToken);
        
        _logger.LogInformation("Question created with id {questionId}", questionId);

        return questionId;
    }
    
    //
    // public async Task<IActionResult> Update([FromRoute] Guid questionId, [FromBody] UpdateQuestionDto request, CancellationToken cancellationToken)
    // {
    // }
    //
    // public async Task<IActionResult> Delete(Guid request, CancellationToken cancellationToken)
    // {
    // }
    //
    // public async Task<IActionResult> SelecteSolution(Guid questionId, Guid answerId, CancellationToken cancellationToken)
    // {
    // }
    //
    // public async Task<IActionResult> AddAnswer(Guid questionId, AddAnswerDto request, CancellationToken cancellationToken)
    // {
    // }
}
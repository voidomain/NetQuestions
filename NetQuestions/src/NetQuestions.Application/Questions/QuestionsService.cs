using FluentValidation;
using Microsoft.Extensions.Logging;
using NetQuestion.Contracts;
using NetQuestion.Contracts.Questions;
using NetQuestions.Application.Extensions;
using NetQuestions.Application.FullTextSearch;
using NetQuestions.Application.Questions.Exceptions;
using NetQuestions.Application.Questions.Fails;
using NetQuestions.Application.Questions.Fails.Exceptions;
using NetQuestions.Entity.Questions;
using Shared;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace NetQuestions.Application.Questions;

public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository _questionsRepository;
    private readonly ISearchProvider _searchProvider;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;

    public QuestionsService(
        IValidator<CreateQuestionDto> validator,
        IQuestionsRepository questionsRepository, 
        ISearchProvider searchProvider,
        ILogger<QuestionsService> logger)
    {
        _questionsRepository = questionsRepository;
        _validator = validator;
        _searchProvider = searchProvider;
        _logger = logger;
    }

    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new QuestionValidationException(validationResult.ToErrors());
        }
        
        int openUserQuestionsCount = await _questionsRepository
            .GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);

        var existedQuestion = await _questionsRepository.GetByIdAsync(Guid.Empty, cancellationToken);
        
        if (openUserQuestionsCount > 3)
        {
            throw new ToManyQuestionsException();
        }
        
        var questionId = Guid.NewGuid();

        var question = new Question(
            questionId,
            questionDto.Title,
            questionDto.Text,
            questionDto.UserId,
            null,
            questionDto.TagIds);

        await _questionsRepository.AddAsync(question, cancellationToken);

        await _searchProvider.IndexQuestionAsync(question);
        
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
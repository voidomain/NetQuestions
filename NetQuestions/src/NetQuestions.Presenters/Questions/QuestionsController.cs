using Microsoft.AspNetCore.Mvc;
using NetQuestion.Contracts.Questions;
using NetQuestions.Application.Questions;

namespace NetQuestions.Presenters.Questions;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionsService _questionsService;

    public QuestionsController(IQuestionsService questionsService)
    {
        _questionsService = questionsService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuestionDto request, CancellationToken cancellationToken)
    {
        var questionId = await _questionsService.Create(request, cancellationToken);
        return Ok(questionId);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetQuestionsDto request, CancellationToken cancellationToken)
    {
        return Ok("Questions get");
    }
    
    [HttpGet("{questionId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid request, CancellationToken cancellationToken)
    {
        return Ok("Questions getbyid");
    }
    
    [HttpPut("{questionId:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid questionId, [FromBody] UpdateQuestionDto request, CancellationToken cancellationToken)
    {
        return Ok("Questions updated");
    }
    
    [HttpDelete("{questionId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
    {
        return Ok("Questions deleted");
    }

    [HttpPut("{questionId:guid}/solution")]
    public async Task<IActionResult> SelecteSolution([FromRoute] Guid questionId, [FromQuery] Guid answerId, CancellationToken cancellationToken)
    {
        return Ok("Solution selected");  
    }
    
    [HttpPost("{questionId:guid}/answers")]
    public async Task<IActionResult> AddAnswer([FromRoute] Guid questionId, [FromBody] AddAnswerDto request, CancellationToken cancellationToken)
    {
        return Ok("Answer added");
    }
}


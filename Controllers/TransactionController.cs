using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
namespace Controllers
{
    [ApiController]
    [Route("api/transactions")]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _service;
        public TransactionController(ITransactionRepository service)
        {
            _service = service;
        }

        private string _get_user_id()
        {
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            var userIdClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim.Value;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetTransactionResponseDto>>> Get([FromQuery, SwaggerParameter(Description = "Формат даты: yyyy.MM.dd")]string? firstDate, [FromQuery, SwaggerParameter(Description = "Формат даты: yyyy.MM.dd")]string? lastDate, [FromQuery, SwaggerParameter(Description = "Минимальная сумма:")]decimal? amount1,[FromQuery, SwaggerParameter(Description = "Максимальная сумма:")] decimal? amount2, [FromQuery] GetTransactionRequestDto? request)
        {
            // string date1ToString = firstDate?.ToString("yyyy-MM-dd");
            // string date2ToString = lastDate?.ToString("yyyy-MM-dd");
            string user_id = _get_user_id();
            var transactions = await _service.Get(firstDate, lastDate, amount1, amount2, request, user_id);
            return Ok(new ApiResponse<List<GetTransactionResponseDto>>(transactions, "Список тразакций"));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(TransactionRequestDto transaction)
        {
            var user_id = _get_user_id();
            var transactions = await _service.Create(transaction, user_id);
            return Ok(transactions);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var transaction = await _service.Delete(Id);
            return Ok(transaction);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update(Guid Id, TransactionRequestDto transaction)
        {
            var transactions = await _service.Update(Id, transaction);
            return Ok(new ApiResponse<TransactionResponseDto>(transactions, "Транзакция изменена"));
        }
    }
}
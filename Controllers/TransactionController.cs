namespace Controllers
{
    [ApiController]
    [Route("api/transactions")]
    [Authorize]
    public class TransactionController : ApiBaseController
    {
        private readonly ITransactionService _service;
        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetTransactionResponseDto>>> Get([FromQuery, SwaggerParameter(Description = "Формат даты: yyyy.MM.dd")]string? firstDate, [FromQuery, SwaggerParameter(Description = "Формат даты: yyyy.MM.dd")]string? lastDate, [FromQuery, SwaggerParameter(Description = "Минимальная сумма:")]decimal? amount1,[FromQuery, SwaggerParameter(Description = "Максимальная сумма:")] decimal? amount2, [FromQuery] GetTransactionRequestDto? request)
        {
            Guid user_id = UserId;
            var transactions = await _service.GetFilter(firstDate, lastDate, amount1, amount2, request, user_id);
            return Ok(new ApiResponse<List<GetTransactionResponseDto>>(transactions, "Список тразакций"));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]TransactionRequestDto transaction)
        {
            Guid user_id = UserId;
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
            return Ok(new ApiResponse<bool>(transactions, "Транзакция изменена"));
        }
    }
}
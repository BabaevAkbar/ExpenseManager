namespace Controllers
{
    [ApiController]
    [Route("api/balance")]
    [Authorize]
    public class ControllerBalance: ApiBaseController
    {
        private readonly ITransactionCalculateRepository _service;
        public ControllerBalance(ITransactionCalculateRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetBalance()
        {
            Guid user_id = UserId;
            var balance = await _service.Calculate(user_id);
            return Ok(new ApiResponse<decimal>(balance, "Баланс"));
        }
    }

}
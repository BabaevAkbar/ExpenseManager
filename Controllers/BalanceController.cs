using Microsoft.AspNetCore.Authorization;

namespace Controllers
{
    [ApiController]
    [Route("api/balance")]
    [Authorize]
    public class ControllerBalance: ControllerBase
    {
        private readonly ITransactionCalculateRepository _service;
        public ControllerBalance(ITransactionCalculateRepository service)
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
        public async Task<IActionResult> GetBalance()
        {
            string user_id = _get_user_id();
            var balance = await _service.Calculate(user_id);
            return Ok(new ApiResponse<decimal>(balance, "Баланс"));
        }
    }

}
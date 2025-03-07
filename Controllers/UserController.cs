namespace Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _service;
        public UserController(IUserRepository service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDto>> Register([FromBody] RegisterRequest request)
        {
            try
            {
                UserResponseDto user = await _service.RegisterAsync(request);
                return Ok(new ApiResponse<UserResponseDto>(user, "Пользователь успешно зарегистрирован"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(ex.Message));
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {                
                var user = await _service.LoginAsync(request);
                if (user == null)
                {
                    return BadRequest("Некорректные данные");
                }

                return Ok(new ApiResponse<string>(user, "Пользователь успешно авторизован"));
            }
            catch (Exception ex)
            {
                return Unauthorized(new ApiResponse<string>(ex.Message));
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<UserResponseDto>>> Get()
        {
            var users = await _service.Get();
            return Ok(new ApiResponse<List<UserResponseDto>>(users, "Список пользователей"));
        }
    }

}
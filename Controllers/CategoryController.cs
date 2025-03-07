using Microsoft.AspNetCore.Authorization;

namespace Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _service;
        public CategoryController(ICategoryRepository service)
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
        public async Task<IActionResult> Get()
        {
            string user_id = _get_user_id();
            var categories = await _service.Get(user_id);
            return Ok(new ApiResponse<List<CategoryResponseDto>>(categories, "Список категорий"));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var categories = await _service.Delete(Id);
            return Ok(categories);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CategoryRequestDto categoryRequest)
        {
            string user_id = _get_user_id();
            var category = await _service.Create(categoryRequest, user_id);
            return Ok(category);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update(Guid Id, CategoryRequestDto categoryRequest)
        {
            var categories = await _service.Update(Id, categoryRequest);
            return Ok(new ApiResponse<CategoryResponseDto>(categories, "Категория изменена"));
        }
    }
}
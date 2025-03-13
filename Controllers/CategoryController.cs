namespace Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize]
    public class CategoryController : ApiBaseController
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CategoryRequestDto categoryRequest)
        {
            Guid user_id = UserId;
            var categories = await _service.Get(categoryRequest, user_id);
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
            Guid user_id = UserId;
            var category = await _service.Create(categoryRequest, user_id);
            return Ok(category);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update(Guid Id, CategoryRequestDto categoryRequest)
        {
            var categories = await _service.Update(Id, categoryRequest);
            return Ok(new ApiResponse<bool>(categories, "Категория изменена"));
        }
    }
}
namespace ExpenseApi.Interface.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> GetById(Guid user_id);
        Task<CategoryResponseDto> GetByName(string name);
        Task<List<CategoryResponseDto>> Get(CategoryRequestDto categoryRequest, Guid user_id);
        Task<Guid> Create(CategoryRequestDto categoryRequest, Guid user_id);
        Task<bool> Delete(Guid Id);
        Task<bool> Update(Guid Id, CategoryRequestDto category);
    }
}
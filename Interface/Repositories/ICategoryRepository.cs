namespace ExpenseApi.Interface.Repositories
{
    public interface ICategoryRepository
    {
        Task<CategoryResponseDto> Create(CategoryRequestDto category, string user_id);
        Task<bool> Delete(Guid Id);
        Task<List<CategoryResponseDto>> Get(string user_id);
        Task<CategoryResponseDto> Update(Guid Id, CategoryRequestDto category);
    }
}
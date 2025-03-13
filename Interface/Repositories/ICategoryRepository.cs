namespace ExpenseApi.Interface.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<List<CategoryResponseDto>> Get(CategoryRequestDto categoryRequest, Guid user_id);
        Task<Category> GetById(Guid user_id);
        Task<Category> GetByName(string name);
        void Update(Category category);
        void Delete(Category category);
        Task<bool> ExistsAsync(CategoryRequestDto category, Guid user_id);
    }
}
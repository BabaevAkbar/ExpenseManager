namespace ExpenseApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExpenseManagerDbContext _context;
        public CategoryRepository(ExpenseManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync(CancellationToken.None);
        }


        public async Task<List<CategoryResponseDto>> Get(CategoryRequestDto? categoryRequest, Guid user_id)
        {
            var allCategory = _context.Category.Where(c => c.UserId == user_id || c.Name == categoryRequest.Name).AsQueryable();
            var categoryResponse = await allCategory.Select(p => new CategoryResponseDto{Id = p.Id, Name = p.Name, UserID = p.UserId, CreateAt = p.CreateAt}).ToListAsync();
            return categoryResponse;
        }

        public async Task<Category> GetById(Guid user_id)
        {
            return await _context.Category.FindAsync(user_id);
        }

        public async Task<Category> GetByName(string name)
        {
            return await _context.Category.FindAsync(name);
        }


        public void Delete(Category category)
        {
            _context.Category.Remove(category);
            _context.SaveChanges();
        }

        public async Task<bool> ExistsAsync(CategoryRequestDto categoryRequest, Guid user_id)
        {
            return await _context.Category.AnyAsync(c => c.Name == categoryRequest.Name && c.UserId == user_id);
        }

        public void Update(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();
        }
    }
}
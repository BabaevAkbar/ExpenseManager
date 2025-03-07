namespace ExpenseApi.Repositories
{
    public class CategoryRepository(ExpenseManagerDbContext context) : ICategoryRepository
    {
        public async Task<CategoryResponseDto> Create(CategoryRequestDto categoryRequest, string user_id)
        {
            var user = await context.Users.FindAsync(Guid.Parse(user_id));
            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            if (user.Name == categoryRequest.Name) 
            {
                throw new Exception("Категория с таким именем уже существует");
            }
            

            Category category = new Category
            {
                Id = Guid.NewGuid(),
                Name = categoryRequest.Name,
                UserId =  Guid.Parse(user_id),
            };
            await context.AddAsync(category);
            await context.SaveChangesAsync();

            CategoryResponseDto categoryResponseDto = new CategoryResponseDto
            {
                Id = category.Id,
                UserID = category.UserId,
                Name = category.Name,
                CreateAt = category.CreateAt
            };
            return categoryResponseDto;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var removeCategory = await context.Category.FindAsync(Id);
            if (removeCategory != null)
            {
                context.Category.RemoveRange(removeCategory);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<CategoryResponseDto>> Get(string user_id)
        {
            var allCategory = await Task.Run(()=> context.Category.Where(c => c.UserId == Guid.Parse(user_id)));
            var categoryResponse = allCategory.Select(p => new CategoryResponseDto{Id = p.Id, Name = p.Name, UserID = p.UserId, CreateAt = p.CreateAt}).ToList();
            return categoryResponse;
        }

        public async Task<CategoryResponseDto> Update(Guid Id, CategoryRequestDto category)
        {
            var updateCategory = await context.Category.FirstOrDefaultAsync(c => c.Id == Id);
            if (updateCategory == null)
            {
                throw new Exception("Категория не найдена");
            }
            if (updateCategory.Name == category.Name) 
            {
                throw new Exception("Категория с таким именем уже существует");
            }
            updateCategory.Name = category.Name;

            await context.SaveChangesAsync();

            return new CategoryResponseDto
            {
                Id = updateCategory.Id,
                Name = updateCategory.Name,
                CreateAt = updateCategory.CreateAt
            };
            
        }
    }
}
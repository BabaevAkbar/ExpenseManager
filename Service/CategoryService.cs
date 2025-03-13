namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Create(CategoryRequestDto categoryRequest, Guid user_id)
        {
            bool categorys = await _repository.ExistsAsync(categoryRequest, user_id);
            if (categorys)
            {
                throw new Exception("Категория с таким именем уже существует");
            }
            Category category = new Category
            {
                Id = Guid.NewGuid(),
                Name = categoryRequest.Name,
                UserId =  user_id,
            };
            await _repository.AddAsync(category);
            return category.Id;
        }

        public async Task<List<CategoryResponseDto>> Get(CategoryRequestDto? categoryRequest, Guid user_id)
        {
            if (categoryRequest == null)
            {
                return await _repository.Get(null, user_id);
            }
            return await _repository.Get(categoryRequest, user_id);
        }

        public async Task<bool> Delete(Guid Id)
        {
            var category = await _repository.GetById(Id);
            if (category == null)
            {
                throw new Exception($"Категория с ID {Id} не найдена.");
            }
            _repository.Delete(category);
            return true;
        }

        public async Task<CategoryResponseDto> GetById(Guid user_id)
        {
            var category = await _repository.GetById(user_id);
            if (category == null)
            {
                throw new Exception("Категория не найдена");
            }
            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                CreateAt = category.CreateAt
            };
        }

        public async Task<CategoryResponseDto> GetByName(string name)
        {
            var category = await _repository.GetByName(name);
            if (category == null)
            {
                throw new Exception("Категория не найдена");
            }
            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                CreateAt = category.CreateAt
            };
        }

        public async Task<bool> Update(Guid Id, CategoryRequestDto categoryDto)
        {
           var category = await _repository.GetById(Id);
           if (category == null)
           {
                throw new Exception("Категория не найдена");
           }
           category.Name = categoryDto.Name;
           _repository.Update(category);
           return true;
        }
    }
}
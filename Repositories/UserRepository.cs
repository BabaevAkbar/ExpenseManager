namespace ExpenseApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseManagerDbContext _context;
        private readonly IJwtService _jwtService;

        public UserRepository(ExpenseManagerDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }
        public async Task<string> LoginAsync(LoginRequest login)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == login.Email);
            
            if(user == null)
            {
                throw new Exception("Неправильный логин");
            }

            var userPassword = login.Password;
            var passwordBd = user.PasswordHash;
            bool result = VerifyPassword(userPassword, passwordBd);

            if (!result)
            {
                throw new Exception("Неправильный пароль");
            }

            var token = _jwtService.GenerateToken(user);

            return token;
        }

        public async Task<UserResponseDto> RegisterAsync(RegisterRequest request)
        {
            if(await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                throw new Exception("Пользователь с таким email уже существует");
            }

            User user = new User
            {
                Email = request.Email,
                Name = request.Name,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreateAt = DateTime.Now.ToString()
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Eamil = user.Email,
                CreateAt = user.CreateAt
            };
        }

        private static bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
        private static string GetPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task<List<UserResponseDto>> Get()
        {
            var allUser = await _context.Users.ToListAsync();
            var userInfo = allUser.Select(u => new UserResponseDto{Id = u.Id, Name = u.Name, Eamil = u.Email, CreateAt = u.CreateAt}).ToList();
            return userInfo;
        }
    }
}
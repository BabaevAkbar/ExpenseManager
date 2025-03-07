namespace ExpenseApi.Interface.Repositories
{
    public interface IUserRepository
    {
        Task<UserResponseDto> RegisterAsync(RegisterRequest request);
        Task<string> LoginAsync(LoginRequest login);
        Task<List<UserResponseDto>> Get();
    }
}
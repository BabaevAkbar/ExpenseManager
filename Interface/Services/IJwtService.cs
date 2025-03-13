namespace ExpenseApi.Interface.Service
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
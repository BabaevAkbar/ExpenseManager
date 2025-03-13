namespace ExpenseApi.Interface.Repositories
{
    public interface ITransactionCalculateRepository
    {
        Task<decimal> Calculate(Guid user_id);
    }
}
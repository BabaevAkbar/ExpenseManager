namespace ExpenseApi.Interface.Repositories
{
    public interface ITransactionCalculateRepository
    {
        Task<decimal> Calculate(string user_id);
    }
}
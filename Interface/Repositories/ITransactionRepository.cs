namespace ExpenseApi.Interface.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transactions transactions);
        Task<List<Transactions>> GetFilter(string? date1, string? date2, decimal? amount1, decimal? amount2, GetTransactionRequestDto? request, Guid user_id);
        Task<Transactions> GetById(Guid Id);
        Task<List<Transactions>> Get(Guid Id);
        void Delete(Transactions transaction);
        void  Update(Transactions transaction);
        Task<bool> ExistsAsync(TransactionRequestDto getDto, Guid id);
    }
}
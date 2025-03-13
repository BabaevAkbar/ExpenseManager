namespace ExpenseApi.Interface.Services
{
    public interface ITransactionService
    {
        Task<Guid> Create(TransactionRequestDto transaction, Guid user_id);
        Task<List<GetTransactionResponseDto>> GetFilter(string? date1, string? date2, decimal? amount1, decimal? amount2, GetTransactionRequestDto? request, Guid user_id);
        Task<bool> Delete(Guid Id);
        Task<bool> Update(Guid Id, TransactionRequestDto transaction);

    }
}
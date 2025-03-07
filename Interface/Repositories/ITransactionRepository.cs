namespace ExpenseApi.Interface.Repositories
{
    public interface ITransactionRepository
    {
        Task<TransactionResponseDto> Create(TransactionRequestDto transaction, string user_id);
        Task<List<GetTransactionResponseDto>> Get(string? date1, string? date2, decimal? amount1, decimal? amount2, GetTransactionRequestDto? request, string user_id);
        Task<bool> Delete(Guid Id);
        Task<TransactionResponseDto> Update(Guid Id, TransactionRequestDto transaction);

    }
}
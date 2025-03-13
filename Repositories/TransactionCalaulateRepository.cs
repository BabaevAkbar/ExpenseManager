namespace ExpenseApi.Repositories
{
    public class TransactionCalculateRepository(ExpenseManagerDbContext context) : ITransactionCalculateRepository
    {
        public async Task<decimal> Calculate(Guid user_id)
        {
            var operation = await context.Transactions.Where(i => i.UserId == user_id).ToListAsync();
            decimal result = 0;
            foreach (var item in operation)
            {
                if (item.Type == 0)
                {
                    result += item.Amount;
                }
                else if ((int)item.Type == 1)
                {
                    result -= item.Amount;
                }
            }
            return result;
        }
    }
}
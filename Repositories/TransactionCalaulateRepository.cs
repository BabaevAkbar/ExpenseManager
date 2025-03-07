namespace ExpenseApi.Repositories
{
    public class TransactionCalculateRepository(ExpenseManagerDbContext context) : ITransactionCalculateRepository
    {
        public async Task<decimal> Calculate(string user_id)
        {
            var operation = await context.Transactions.Where(i => i.UserId == Guid.Parse(user_id)).ToListAsync();
            var income = operation.Where(i => i.Type == 0);
            var expense = operation.Where(k => (int)k.Type == 1);
            decimal resultIncome = 0;
            decimal resultExpense = 0;
            foreach (var item in income)
            {
                resultIncome =+ item.Amount;
            }
            foreach (var item in expense)
            {
                resultExpense =+ item.Amount;
            }

            return resultIncome - resultExpense;
        }
    }
}
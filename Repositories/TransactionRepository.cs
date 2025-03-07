namespace ExpenseApi.Repositories
{
    public class TransactionRepository(ExpenseManagerDbContext context) : ITransactionRepository
    {
        public async Task<TransactionResponseDto> Create(TransactionRequestDto transaction, string user_id )
        {
            var user = await context.Users.FindAsync(Guid.Parse(user_id));
            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            if (transaction.Amount <= 0)
            {
                throw new Exception("Сумма должна быть больше 0");
            }
            Transactions newTransaction = new Transactions
            {
                UserId = Guid.Parse(user_id),
                CategoryId = transaction.CategoryId,
                Type = transaction.Type,
                Amount = transaction.Amount,
                Note = transaction.Note
            };

            await context.AddAsync(newTransaction);
            await context.SaveChangesAsync();

            TransactionResponseDto responseDto = new TransactionResponseDto
            {
                Id = Guid.NewGuid(),
                CategoryId = newTransaction.CategoryId,
                Type = newTransaction.Type,
                Amount = newTransaction.Amount,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            };

            return responseDto;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var removeTransaction = await context.Transactions.FindAsync(Id);
            if (removeTransaction != null)
            {
                context.Transactions.RemoveRange(removeTransaction);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<GetTransactionResponseDto>> Get(string? date1, string? date2, decimal? amount1, decimal? amount2, GetTransactionRequestDto? request, string user_id)
        {
            var allTransaction = await context.Transactions.ToListAsync();
            if (date1 == null && date2 == null && amount1 == null && amount2 == null && request.CategoryId == null && request.Type == null && request.Id == Guid.Parse(user_id))
            {
                var transactionResponse = allTransaction.Select(p => new GetTransactionResponseDto{Id = p.Id, Amount = p.Amount, CategoryId = p.CategoryId, UserId = p.UserId, CteateAt = p.Date, Type = p.Type, Note = p.Note}).ToList();
                return transactionResponse;
            }
            var transaction = allTransaction.Where(t => (DateTime.Parse(t.Date) >= DateTime.Parse(date1) && DateTime.Parse(t.Date) <= DateTime.Parse(date2)) || (t.Amount >= amount1 && t.Amount <= amount2) || t.Id == request.Id || t.UserId == Guid.Parse(user_id) || t.CategoryId == request.CategoryId || t.Type == request.Type).ToList();
            var result = transaction.Select(t => new GetTransactionResponseDto
            {
                Id = t.Id,
                Amount = t.Amount,
                CteateAt = t.Date,
                CategoryId = t.CategoryId,
                Type = t.Type,
                Note = t.Note
            }).ToList();

            return result;
        }

        public async Task<TransactionResponseDto> Update(Guid Id, TransactionRequestDto transaction)
        {
            var updateTransaction = await context.Transactions.FirstOrDefaultAsync(c => c.Id == Id);
            if (updateTransaction == null)
            {
                throw new Exception("Транзакция не найдена");
            }
            
            updateTransaction.Amount = transaction.Amount;
            updateTransaction.CategoryId = transaction.CategoryId;
            updateTransaction.Type = transaction.Type;
            updateTransaction.Note = transaction.Note;
            updateTransaction.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            await context.SaveChangesAsync();

            return new TransactionResponseDto
            {
                Id = updateTransaction.Id,
                Amount = updateTransaction.Amount,
                CategoryId = updateTransaction.CategoryId,
                Type = updateTransaction.Type,
                CreateAt = updateTransaction.Date
            };
        }
    }
}

namespace Service
{
    public class TransactionsServise : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        public TransactionsServise(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Create(TransactionRequestDto transactionDto, Guid user_id)
        {
            bool transaction = await _repository.ExistsAsync(transactionDto, user_id);
            if (transaction == null)
            {
                throw new Exception("Транзакция не найдена");
            }
            Transactions newTransaction = new Transactions
            {
                Id = Guid.NewGuid(),
                UserId = user_id,
                CategoryId = transactionDto.CategoryId,
                Type = transactionDto.Type,
                Amount = transactionDto.Amount,
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Note = transactionDto.Note
            };

            await _repository.AddAsync(newTransaction);
            return newTransaction.Id;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var transaction = await _repository.GetById(Id);
            if (transaction == null)
            {
                throw new Exception("Транзакция не найдена");
            }
            _repository.Delete(transaction);
            return true;
        }

        public async Task<List<GetTransactionResponseDto>> GetFilter(string? date1, string? date2, decimal? amount1, decimal? amount2, GetTransactionRequestDto? request, Guid user_id)
        {
            List<Transactions> transactions;
            if (string.IsNullOrEmpty(date1) && string.IsNullOrEmpty(date2) && !amount1.HasValue && !amount2.HasValue && request?.CategoryId == null && request?.Type == null && request?.Id == null)
            {
                transactions = await _repository.Get(user_id);
                var transactionResponse = transactions.Select(p => new GetTransactionResponseDto{Id = p.Id, Amount = p.Amount, CategoryId = p.CategoryId, UserId = p.UserId, CteateAt = p.Date, Type = p.Type, Note = p.Note}).ToList();
                return transactionResponse;
            }
            transactions = await _repository.GetFilter(date1, date2, amount1, amount2, request, user_id);
            var transaction = transactions.Where(t => (DateTime.Parse(t.Date) >= DateTime.Parse(date1) && DateTime.Parse(t.Date) <= DateTime.Parse(date2)) || (t.Amount >= amount1 && t.Amount <= amount2) || t.Id == request.Id || t.UserId == user_id || t.CategoryId == request.CategoryId || t.Type == request.Type).ToList();
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
        public async Task<TransactionResponseDto> GetById(Guid Id)
        {
            var transaction = await _repository.GetById(Id);
            if (transaction == null)
            {
                throw new Exception("Транзакция не найдена");
            }
            return new TransactionResponseDto
            {
                Id = transaction.Id,
                CategoryId = transaction.CategoryId,
                CreateAt = transaction.Date,
                Type = transaction.Type,
                Amount = transaction.Amount
            };
        }

        public async Task<bool> Update(Guid Id, TransactionRequestDto transaction)
        {
            var updateTransaction = await _repository.GetById(Id);  
            if (updateTransaction == null)
            {
                throw new Exception("Транзакция не найдена");
            }
            
            updateTransaction.Amount = transaction.Amount;
            updateTransaction.CategoryId = transaction.CategoryId;
            updateTransaction.Type = transaction.Type;
            updateTransaction.Note = transaction.Note;
            updateTransaction.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            _repository.Update(updateTransaction);

            return true;
        }
    }
}
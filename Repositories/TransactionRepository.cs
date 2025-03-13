namespace ExpenseApi.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
    private readonly ExpenseManagerDbContext _context;
        public TransactionRepository(ExpenseManagerDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Transactions transactions)
        {
            await _context.Transactions.AddAsync(transactions);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public void Delete(Transactions transaction)
        {
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
        }

        public async Task<bool> ExistsAsync(TransactionRequestDto getDto, Guid id)
        {
            return await _context.Transactions.AnyAsync(t => t.Id == id && t.CategoryId == getDto.CategoryId || t.Type == getDto.Type);
        }

        public async Task<List<Transactions>> GetFilter(string? date1, string? date2, decimal? amount1, decimal? amount2, GetTransactionRequestDto? request, Guid user_id)
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transactions> GetById(Guid Id)
        {
            return await _context.Transactions.FindAsync(Id);
        }

        public async Task<List<Transactions>> Get(Guid User_Id)
        {
            return await _context.Transactions.Where(t => t.UserId == User_Id).ToListAsync();
        }

        public void Update(Transactions transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }
    }
}
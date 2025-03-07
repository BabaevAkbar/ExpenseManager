namespace ExpenseApi.Transaction
{
    public class Transactions
    {
        public Guid Id{ get; set; }
        public Guid UserId{ get; set; }
        public Guid CategoryId{ get; set; }
        public decimal Amount{ get; set; }
        public Types Type{  get; set; }
        public string Date{ get; set; }
        public string? Note{ get; set; }

        public User? User{ get; set; }
        public Category Category{ get; set; }
    }
}
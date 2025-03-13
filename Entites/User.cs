namespace ExpenseApi.Users
{
    public class User
    {
        public Guid Id{ get; set; }
        public string? Name{ get; set; }
        [EmailAddress]
        public string? Email{ get; set; }
        public string? PasswordHash{ get; set; }
        public string? CreateAt{ get; set; }

        public List<Category> Categories{ get; set; } = new List<Category>();
        public List<Transactions> Transactions{ get; set; } 
    }
}
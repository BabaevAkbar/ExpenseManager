namespace ExpenseApi.Categories
{
    public class Category
    {
        public Guid Id{ get; set; }
        public Guid UserId{ get; set; }
        public string? Name{ get; set; }
        public Types Type{ get; set; }
        public User? User{ get; set; }
        public string CreateAt{ get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public List<Transactions> Transactions{ get; set; }
    }
}
namespace ExpenseApi.Context
{
    public class ExpenseManagerDbContext : DbContext
    {
        public ExpenseManagerDbContext(DbContextOptions<ExpenseManagerDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users{ get; set; }
        public DbSet<Category> Category{ get; set; }
        public DbSet<Transactions> Transactions{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }

    
}
namespace Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Category)
                    .WithMany(b => b.Transactions)
                    .HasForeignKey(b => b.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
            builder.HasOne(t => t.User)
                    .WithMany(u => u.Transactions)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }    
}
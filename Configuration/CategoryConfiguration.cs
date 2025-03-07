namespace Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(a => a.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.HasOne(u => u.User)
                    .WithMany(c => c.Categories)
                    .HasForeignKey(k => k.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
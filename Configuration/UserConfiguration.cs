    namespace Configuration
    {
        public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasKey(b => b.Id);
                builder.Property(b => b.Name)
                        .IsRequired()
                        .HasMaxLength(30);

            }
        }
    }
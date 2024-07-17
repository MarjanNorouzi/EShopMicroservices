namespace Ordering.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            customerId => customerId.Value,
            dbId => CustomerId.Of(dbId));

        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

        builder.Property(c => c.Email).HasMaxLength(255);

        //TODO: بعدا ببینم منظورش اینه مقدار تکراری تو دیتابیس نمیشه وارد کرد؟ چه ربطی به ایندکس داره؟
        builder.HasIndex(c => c.Email).IsUnique();
    }
}
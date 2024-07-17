namespace Ordering.Infrastructure.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);

        // وقتی مقدار آیدی را در دیتابیس میخواهد ذخیره کند، تبدیل به
        // GUID
        // میکند و وقتی میخواهد بخواند به ولیوآبجکت آیدی
        // OrderItemId
        // مپ میکند
        builder.Property(oi => oi.Id).HasConversion(
            orderItemId => orderItemId.Value,
            dbId => OrderItemId.Of(dbId));

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(oi => oi.ProductId);

        builder.Property(oi => oi.Quantity).IsRequired();

        builder.Property(oi => oi.Price).IsRequired();
    }
}
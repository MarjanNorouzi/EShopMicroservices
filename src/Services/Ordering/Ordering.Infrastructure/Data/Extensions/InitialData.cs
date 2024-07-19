namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
    [
        Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), "marjan", "marjan33norouzi@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), "john", "john@gmail.com")
    ];
    public static IEnumerable<Product> Products =>
    [
        Product.Create(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), "IPhone X", 500),
        Product.Create(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), "Samsung 10", 400),
        Product.Create(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), "Huawei Plus", 650),
        Product.Create(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), "Xiaomi Mi", 450)
    ];

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("marjan", "norouzi", "marjan33norouzi@gmail.com", "mehrabad", "Iran", "Tehran", "12223");
            var address2 = Address.Of("marjan2", "norouzi2", "marjan33norouzi@gmail.com2", "mehrabad2", "Iran2", "Tehran2", "12224");

            var payment1 = Payment.Of("marjan", "1111222233334444", "12/28", "123", 1);
            var payment2 = Payment.Of("marjan2", "5555666677778888", "06/3", "456", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                OrderName.Of("Order 1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);

            order1.Add(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 2, 500);
            order1.Add(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), 1, 400);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
                OrderName.Of("Order 2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);

            order2.Add(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), 2, 500);
            order2.Add(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), 1, 400);

            return [order1, order2];
        }
    }
}

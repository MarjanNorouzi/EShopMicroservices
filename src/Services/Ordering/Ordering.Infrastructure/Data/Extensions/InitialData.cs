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
    public static IEnumerable<Order> OrdersWithItems =>
    [
        //Order.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), "marjan", "marjan33norouzi@gmail.com"),
        //Order.Create(CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), "john", "john@gmail.com")
    ];
}

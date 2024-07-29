namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellationToken)
    {
        using var session = store.LightweightSession();
        
        if (await session.Query<Product>().AnyAsync(cancellationToken))
            return;

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellationToken);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() =>
        [
            new()
            {
                Id = new Guid("ec121c65-c1b9-4874-ab0e-979a5c8b2ee4"),
                Name = "IPhone X",
                Description = "This phone is the company's biggest change",
                ImageFile = "product-1.png",
                Price = 950.00M,
                Categories = ["Smart Phone"]
            },
            new()
            {
                Id = new Guid("ff69108c-e511-4937-acb5-f236ed7fece5"),
                Name = "Samsung 10",
                Description = "This phone is the company's biggest change",
                ImageFile = "product-2.png",
                Price = 840.00M,
                Categories = ["Smart Phone"]
            },
            new()
            {
                Id = new Guid("fe60547c-79e5-4b85-9a5a-cccf241b97fc"),
                Name = "Huawei Plus",
                Description = "This phone is the company's biggest change",
                ImageFile = "product-3.png",
                Price = 650.00M,
                Categories = ["White Appliances"]
            },
            new()
            {
                Id = new Guid("f4725a6f-1b16-4efb-a33a-2bf102b45e78"),
                Name = "Xiaomi Mi 9",
                Description = "This phone is the company's biggest change",
                ImageFile = "product-4.png",
                Price = 470.00M,
                Categories = ["White Appliances"]
            },
            new()
            {
                Id = new Guid("ccc0d453-2ab5-4413-b2d2-be79b1093ffe"),
                Name = "HTC U11+ Plus",
                Description = "This phone is the company's biggest change",
                ImageFile = "product-5.png",
                Price = 240.00M,
                Categories = ["Smart Phone"]
            },
            new()
            {
                Id = new Guid("28a51dc0-b174-4582-be20-0a2c914abeaa"),
                Name = "LG G7 ThinQ",
                Description = "This phone is the company's biggest change",
                ImageFile = "product-6.png",
                Price = 240.00M,
                Categories = ["Home Kitchen"]
            },
            new()
            {
                Id = new Guid("9ea9847f-f19a-409a-a08d-e51a241f4488"),
                Name = "Panasonic Lumix",
                Description = "This phone is the company's biggest change",
                ImageFile = "product-6.png",
                Price = 240.00M,
                Categories = ["Camera"]
            }
        ];
}

using Bogus;
using ShopOnline.API.Entites.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace ShopOnline.API.Extensions;

public static class ModelExtensions
{

    public static void Seed(this ModelBuilder modelBuilder)
    {

        var random = new Random();

        var faker = new Faker();

        var fitTypes = new List<FitType>
        {
            new FitType { Id = 1, Name = FitTypeEnum.REGULAR.ToString() },
            new FitType { Id = 2, Name = FitTypeEnum.OVERSIZE.ToString()}
        };

        var categories = new List<Category>()
        {
            new Category { Id = 1, Name = CategoryEnum.SHIRT.ToString() },
            new Category { Id = 2, Name = CategoryEnum.BASIC.ToString() },
            new Category { Id = 3, Name = CategoryEnum.SHIRT.ToString() },
            new Category { Id = 4, Name = CategoryEnum.PRTINED.ToString() }
        };

        var sizes = new List<Size>()
        {
            new Size { Id = 1, Name = SizeEnum.S.ToString() },
            new Size { Id = 2, Name = SizeEnum.M.ToString() },
            new Size { Id = 3, Name = SizeEnum.L.ToString() },
            new Size { Id = 4, Name = SizeEnum.XL.ToString() },
            new Size { Id = 5, Name = SizeEnum.XXL.ToString() }
        };

        modelBuilder.Entity<Category>()
            .HasData(categories);

        modelBuilder.Entity<Size>()
            .HasData(sizes);

        modelBuilder.Entity<FitType>()
            .HasData(fitTypes);

        var productGenerator = new Faker<Product>()
                .RuleFor(x => x.Name, x => x.Commerce.ProductName())
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .RuleFor(x => x.Price, x => Convert.ToDecimal(x.Commerce.Price()))
                .RuleFor(x => x.Qty, x => x.Random.Int(1, 1000))
                .RuleFor(x => x.Sizes, sizes.GetRange(0, 2))
                .RuleFor(x => x.FitTypes, fitTypes.GetRange(0, 2))
                .RuleFor(x => x.Categories, categories.GetRange(0, 2))
                .Ignore(x => x.Id);


        var products = productGenerator.Generate(20);
        var productIds = new List<int>();
        for (int i = 0; i < 20; ++i)
        {
            var product = new Product
            {
                Id = i + 1,
                Name = products[i].Name,
                Description = products[i].Description,
                Qty = products[i].Qty,
                Price = products[i].Price,

            };
            
            modelBuilder.Entity<Product>().HasData(product);
            productIds.Add(i + 1);
        }


        int counter = 1;
        for (int i = 0; i < productIds.Count; ++i)
        {
            for (int j = 0; j < 2; ++j)
            {
                var image = faker.Image.LoremFlickrUrl(640, 480, "clothes, fashion, model, shirt");
                modelBuilder.Entity<ProductImage>()
                    .HasData(new ProductImage
                    {
                        Id = counter++,
                        ImageUrl = image,
                        ProductId = productIds[i]
                    }) ;
            }
            modelBuilder.Entity<ProductCategory>()
                .HasData(
                    new ProductCategory
                    {
                        CategoryId = random.Next(1, 5),
                        ProductId = productIds[i],
                    }
                );
            modelBuilder.Entity<ProductFitType>()
                .HasData(
                    new ProductFitType
                    {
                        FitTypeId = 1,
                        ProductId = productIds[i],
                    },
                    new ProductFitType
                    {
                        FitTypeId = 2,
                        ProductId = productIds[i],
                    }
                );
            modelBuilder.Entity<ProductSize>()
                .HasData(
                    new ProductSize
                    {
                        ProductId = productIds[i],
                        SizeId = 1
                    },
                    new ProductSize
                    {
                        ProductId = productIds[i],
                        SizeId = 2
                    },
                    new ProductSize
                    {
                        ProductId = productIds[i],
                        SizeId = 3
                    }
                );
        }





    }
}


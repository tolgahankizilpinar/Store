using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product { ProductId = 1, CategoryId = 2, ImageUrl = "/images/1.jpg", ProductName = "Computer", Price = 17_000, ShowCase = false },
                new Product { ProductId = 2, CategoryId = 2, ImageUrl = "/images/2.jpg", ProductName = "Keyboard", Price = 1_000, ShowCase = false },
                new Product { ProductId = 3, CategoryId = 2, ImageUrl = "/images/3.jpg", ProductName = "Mouse", Price = 5000, ShowCase = false },
                new Product { ProductId = 4, CategoryId = 2, ImageUrl = "/images/4.jpg", ProductName = "Monitor", Price = 7_000, ShowCase = false },
                new Product { ProductId = 5, CategoryId = 2, ImageUrl = "/images/5.jpg", ProductName = "Deck", Price = 1_500, ShowCase = false },
                new Product { ProductId = 6, CategoryId = 2, ImageUrl = "/images/6.jpg", ProductName = "Printer", Price = 11_000, ShowCase = false },
                new Product { ProductId = 7, CategoryId = 1, ImageUrl = "/images/7.jpg", ProductName = "Biology", Price = 75, ShowCase = false },
                new Product { ProductId = 8, CategoryId = 1, ImageUrl = "/images/8.jpg", ProductName = "Suç ve Ceza", Price = 125, ShowCase = false },
                new Product { ProductId = 9, CategoryId = 1, ImageUrl = "/images/9.jpg", ProductName = "Chess", Price = 150, ShowCase = true },
                new Product { ProductId = 10, CategoryId = 2, ImageUrl = "/images/10.jpg", ProductName = "Akıllı Saat", Price = 450, ShowCase = true },
                new Product { ProductId = 11, CategoryId = 1, ImageUrl = "/images/11.jpg", ProductName = "Database Book", Price = 200, ShowCase = true },
                new Product { ProductId = 17, CategoryId = 2, ImageUrl = "/images/65.jpg", ProductName = "Akıllı Saat Yeni Nesil", Price = 5500, ShowCase = true },
                new Product { ProductId = 18, CategoryId = 1, ImageUrl = "/images/20.jpg", ProductName = "Data", Price = 1100, ShowCase = true },
                new Product { ProductId = 19, CategoryId = 2, ImageUrl = "/images/50.jpg", ProductName = "Koşu Bandı", Price = 9000, ShowCase = false },
                new Product { ProductId = 20, CategoryId = 2, ImageUrl = "/images/45.jpg", ProductName = "Kahve Makinasi", Price = 8000, ShowCase = true },
                new Product { ProductId = 21, CategoryId = 1, ImageUrl = "/images/40.jpg", ProductName = "Deep Learning", Price = 1200, ShowCase = true },
                new Product { ProductId = 22, CategoryId = 1, ImageUrl = "/images/35.jpg", ProductName = "Java Book", Price = 1450, ShowCase = true },
                new Product { ProductId = 23, CategoryId = 1, ImageUrl = "/images/30.jpg", ProductName = "C# Book", Price = 1350, ShowCase = false },
                new Product { ProductId = 24, CategoryId = 2, ImageUrl = "/images/55.jpg", ProductName = "Fotoğraf Makinası", Price = 7750, ShowCase = true }
            );
        }
    }
}
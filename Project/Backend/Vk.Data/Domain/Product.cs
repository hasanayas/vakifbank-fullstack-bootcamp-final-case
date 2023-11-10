using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using Vk.Base;

namespace Vk.Data.Domain;

[Table("Product", Schema = "dbo")]
public class Product : BaseModel
{
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public int ProductQuantity { get; set; }
    public double ProductPrice { get; set; }
    public string ProductInformation { get; set; }

    public virtual List<Basket> Baskets { get; set; }



}


public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.ProductName).IsRequired();
        builder.Property(x => x.ProductQuantity).IsRequired();
        builder.Property(x => x.ProductPrice).IsRequired();
        builder.Property(x => x.ProductInformation).IsRequired();
        builder.Property(x => x.ProductImage).IsRequired();

        builder.HasMany(x => x.Baskets)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);


    }
}
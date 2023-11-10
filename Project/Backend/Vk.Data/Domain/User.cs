using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Vk.Base;

namespace Vk.Data.Domain;

[Table("User", Schema = "dbo")]
public class User : BaseModel
{
    public int UserNumber { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public int UserPasswordRetryCount { get; set; }
    public string UserRole { get; set; }
    public double UserBalance { get; set; }
    public int UserProfitMargin { get; set; }

    public virtual List<Order> Orders { get; set; }
    public virtual List<Address> Addresses { get; set; }
    public virtual List<Basket> Baskets{ get; set; }

}


public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UserNumber).IsRequired();
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.UserEmail).IsRequired().HasMaxLength(100);
        builder.Property(x => x.UserPassword).IsRequired().HasMaxLength(50);
        builder.Property(x => x.UserPasswordRetryCount).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.UserRole).IsRequired().HasMaxLength(10);
        builder.Property(x => x.UserBalance).IsRequired();
        builder.Property(x => x.UserProfitMargin).IsRequired();

        builder.HasIndex(x => x.UserNumber).IsUnique(true);
        builder.HasIndex(x => x.UserEmail).IsUnique(true);

        builder.HasMany(x => x.Orders)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired(true);

        builder.HasMany(x => x.Addresses)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired(true);

        builder.HasMany(x => x.Baskets)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);



    }
}
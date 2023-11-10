using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Vk.Base;

namespace Vk.Data.Domain;

[Table("Address", Schema = "dbo")]
public class Address : BaseModel
{
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public int PostalCode { get; set; }
}




public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {

        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.AddressLine1).HasMaxLength(100).IsRequired();
        builder.Property(x => x.AddressLine2).HasMaxLength(100);
        builder.Property(x => x.City).HasMaxLength(50).IsRequired();
        builder.Property(x => x.County).HasMaxLength(50).IsRequired();
        builder.Property(x => x.PostalCode).HasMaxLength(20).IsRequired();

        builder.HasIndex(x => x.UserId);
    }
}
using Domain.Aggregates.Products;
using Domain.Aggregates.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(p => new { p.ReferenceNumber }).IsUnique();
            builder.HasIndex(p => p.NameAr);
            builder.HasIndex(p => p.NameEn);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);


            builder.OwnsOne<Money>(x => x.Price, price =>
            {
                price.Property(p => p.Value).IsRequired();
                price.Property(p => p.Currency).IsRequired();
            });

            builder.OwnsMany<ProductAttachments>(x => x.Attachments, attachment =>
            {
                attachment.ToTable("ProductAttachments");
                attachment.WithOwner().HasForeignKey("ProductId");
                attachment.Property(p => p.Path).IsRequired();
                attachment.Property(p => p.ContentType).IsRequired();
                attachment.Property(p => p.Order).IsRequired();
            });
        }
    }
}

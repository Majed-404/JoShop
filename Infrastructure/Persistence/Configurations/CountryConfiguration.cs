using Domain.Aggregates.Cities;
using Domain.Aggregates.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.OwnsMany<City>(x => x.Cities, city =>
            {
                //city.ToTable(nameof(City));
                city.ToTable("City");
                city.WithOwner().HasForeignKey("CountryId");
                city.Property(n => n.CityNameAr).IsRequired();
                city.Property(n => n.CityNameEn).IsRequired();
            });
            
        }
    }
}

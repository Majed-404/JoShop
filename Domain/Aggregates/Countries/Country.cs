using Domain.Aggregates.Cities;
using Domain.Aggregates.Products;
using Domain.Common;
using Domain.Exceptions;
using System.Net.Mail;

namespace Domain.Aggregates.Countries
{
    public class Country : BaseAuditableEntity
    {
        public string CountryNameAr { get;}
        public string CountryNameEn { get; }

        public List<City> Cities { get; } = new List<City>();

        private Country() { }

        private Country(string nameAr,string nameEn)
        {
            if(string.IsNullOrWhiteSpace(nameAr))
                throw new ArgumentNullException("Country Arabic name can not be null or empty");

            if (string.IsNullOrWhiteSpace(nameEn))
                throw new ArgumentNullException("Country English name can not be null or empty");

            CountryNameAr = nameAr;
            CountryNameEn = nameEn;
        }

        public static Country Create(Country country)
        {
            return new Country(country.CountryNameAr, country.CountryNameEn);
        }

    }
}

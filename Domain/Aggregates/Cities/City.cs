using Domain.Aggregates.Countries;
using Domain.Common;

namespace Domain.Aggregates.Cities
{
    public class City : BaseAuditableEntity
    {
        public int CityNameAr { get; }
        public int CityNameEn { get; }
        
        // Foreign Key
        public int CountryId { get; set; }
        // Navigation Property
        public Country Country { get; set; }
    }
}

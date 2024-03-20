using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    internal class CustomerAddress
    {
        [Key]
        public int ID{ get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public string Name { get; set; }
        public string StreetName { get; set; }
        public string buildingNumber { get; set; }
        public string NearestLandmark { get; set; }
        public int AddressType { get; set; }
        public string MobileNumber { get; set; }
    }
}

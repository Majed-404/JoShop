using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    internal class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string? MobileNumber { get; set; }

        public int ParentId { get; set; }

    }
}

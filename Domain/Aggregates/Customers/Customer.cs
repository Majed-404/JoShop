using Domain.Aggregates.Customers.ParameterObjects;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Customers
{
    public class Customer : BaseAuditableEntity
    {
        public Guid UserId { get;}
        public string Name { get;}
        public string? MobileNumber { get;}
        public int? Type { get; }

        private Customer()
        {

        }

        private Customer(Guid userId, string name, string mobileNumber, int? type)
        {

            if(string.IsNullOrWhiteSpace(userId.ToString()))
                throw new ArgumentNullException("UserId cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Name cannot be null or empty.");

            UserId = userId;
            Name = name;
            MobileNumber = mobileNumber;
            Type = type;
        }

        public static Customer Create(CustomerInfoParam customer)
        {
            return new Customer(customer.UserId, customer.Name, customer.MobileNumber, customer.Type);
        }


    }
}

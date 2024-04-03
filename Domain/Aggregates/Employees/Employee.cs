using Domain.Aggregates.Customers.ParameterObjects;
using Domain.Aggregates.Customers;
using Domain.Common;
using Domain.Aggregates.Employees.ParameterObjects;

namespace Domain.Aggregates.Employees
{
    internal class Employee : BaseAuditableEntity
    {
        public Guid UserId { get; }
        public string Name { get; }
        public string? MobileNumber { get; }
        public int? ParentId { get; }

        private Employee()
        {

        }

        private Employee(Guid userId, string name, string mobileNumber, int? parenId)
        {

            if (string.IsNullOrWhiteSpace(userId.ToString()))
                throw new ArgumentNullException("UserId cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Name cannot be null or empty.");

            UserId = userId;
            Name = name;
            MobileNumber = mobileNumber;
            ParentId = parenId;
        }

        public static Employee Create(EmployeeInfoParam employee)
        {
            return new Employee(employee.UserId, employee.Name, employee.MobileNumber, employee.ParentId);
        }


    }
}

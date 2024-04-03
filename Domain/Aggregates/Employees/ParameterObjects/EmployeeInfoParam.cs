namespace Domain.Aggregates.Employees.ParameterObjects
{
    public class EmployeeInfoParam
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string? MobileNumber { get; set; }
        public int? ParentId { get; set; }
    }
}

namespace Domain.Aggregates.Customers.ParameterObjects
{
    public class CustomerInfoParam
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string? MobileNumber { get; set; }
        public int? Type { get; set; }
    }
}

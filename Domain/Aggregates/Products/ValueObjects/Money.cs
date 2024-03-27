using Domain.Common;

namespace Domain.Aggregates.Products.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Value { get; }
        public string Currency { get; }

        private Money()
        {
        }


        public Money(decimal value, string currencyIso)
        {
            if (value <= 0)
                throw new InvalidOperationException("Value must be greater than 0");

            if (string.IsNullOrWhiteSpace(currencyIso))
                throw new ArgumentNullException(nameof(currencyIso));

            Value = value;
            Currency = currencyIso;
        }

        public override string ToString()
        {
            return $"{Value} {Currency}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency;
        }
    }
}

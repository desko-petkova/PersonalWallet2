namespace PersonalWallet2.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; }

        public Money(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount can not be negative");

            Amount = amount;
        }
        public Money Add(Money other)
        {
            return new Money(Amount + other.Amount);
        }

        public Money Substract(Money other)
        {
            decimal result = Amount - other.Amount;

            if (result < 0)
                throw new InvalidOperationException("Insufficient availbility");

            return new Money(result);
        }
    }
}

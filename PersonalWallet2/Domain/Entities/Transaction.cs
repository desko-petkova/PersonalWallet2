using PersonalWallet2.Domain.Enums;
using PersonalWallet2.Domain.ValueObjects;

namespace PersonalWallet2.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; private set; }
        public int AccountId { get;}
        public TransactionType Type { get; private set; }
        public Money Amount { get; private set; }
        public DateTime Date { get;}

        public Transaction() { } //JSON

        public Transaction(int id, int accountId, 
            TransactionType type, Money amount, DateTime date)
        {
            if (id <= 0) throw new ArgumentException("Id must be positive");
            if (accountId <= 0) throw new ArgumentException("AccountId must be positive");

            Id = id;
            AccountId = accountId;
            Type = type;
            Amount = amount;
            Date = date;
        }
    }
}

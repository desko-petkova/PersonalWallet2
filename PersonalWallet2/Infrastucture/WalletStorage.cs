using PersonalWallet2.Domain.Entities;

namespace PersonalWallet2.Infrastucture
{
    public class WalletStorage
    {
        public int NextId { get; set; } = 1;
        public List<Account> Accounts { get; set; } = new List<Account>();

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}

using PersonalWallet2.Domain.Entities;

namespace PersonalWallet2.Infrastucture
{
    public class WalletStorage
    {

        public List<Account> Accounts { get; set; } = new List<Account>();

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}

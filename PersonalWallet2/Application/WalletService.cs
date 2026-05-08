using PersonalWallet2.Application.Interfaces;
using PersonalWallet2.Domain.Entities;
using PersonalWallet2.Domain.Enums;
using PersonalWallet2.Domain.ValueObjects;

namespace PersonalWallet2.Application
{
    public class WalletService
    {
        private readonly IAccountRepository accountRepo;
        private readonly ITransactionRepository transactionRepo;

        public WalletService(IAccountRepository accountRepo, ITransactionRepository transactionRepo)
        {
            this.accountRepo = accountRepo;
            this.transactionRepo = transactionRepo;
        }

        public void CreateAccount(string name, AccountType type, decimal amount)
        {
            var account = new Account(
                0,
                name,
                type,
                new Money(amount)
                );
            accountRepo.Save(account);
        }

        public IReadOnlyList<Account> GetAllAccounts()
        {
            return accountRepo.GetAll();
        }

        public void CreateTransaction(int accountId, TransactionType type, decimal amount)
        {
            var account = accountRepo.GetById(accountId);

            var money = new Money(amount);

            if (type == TransactionType.Income)
            {
                account.Deposit(money);
            }
            else
            {
                account.Withdraw(money);
            }

            accountRepo.Save(account);

            var transaction = new Transaction(
                0,
                accountId,
                type,
                money,
                DateTime.Now);

            transactionRepo.Save(transaction);
        }
        public IReadOnlyList<Transaction> GetTransactions(int accountId)
        {
            return transactionRepo.GetByAccountId(accountId);
        }
    }
}

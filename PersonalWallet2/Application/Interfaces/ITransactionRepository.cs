using PersonalWallet2.Domain.Entities;

namespace PersonalWallet2.Application.Interfaces
{
    public interface ITransactionRepository
    {
        void Save(Transaction transaction);
        IReadOnlyList<Transaction> GetByAccountId(int acountId);

    }
}

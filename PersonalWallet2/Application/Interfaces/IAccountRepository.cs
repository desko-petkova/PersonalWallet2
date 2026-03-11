using PersonalWallet2.Domain.Entities;

namespace PersonalWallet2.Application.Interfaces
{
    public interface IAccountRepository
    {
        Account GetById(int id);
        void Save(Account account);
        IReadOnlyList<Account> GetAll();
    }
}

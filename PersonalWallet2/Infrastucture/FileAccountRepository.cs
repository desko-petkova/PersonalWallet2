using PersonalWallet2.Application.Interfaces;
using PersonalWallet2.Domain.Entities;

namespace PersonalWallet2.Infrastucture
{
    public class FileAccountRepository : IAccountRepository
    {
        private readonly FileStorage _storage;

        public FileAccountRepository(FileStorage storage)
        {
            _storage = storage;
        }

        public IReadOnlyList<Account> GetAll()
        {
            var db = _storage.Load();

            return db.Accounts;
        }

        public Account GetById(int id)
        {
            var db = _storage.Load();

            foreach (var account in db.Accounts)
            {
                if(account.Id == id)
                {
                    return account;
                }
            }

            throw new Exception("Account not found");
        }

        public void Save(Account account)
        {
            var db = _storage.Load();

            if (account.Id == 0)
            {
                var newAccount = new Account(
                   db.NextId++,
                   account.Name,
                   account.Type,
                   account.Balance
                    );
                db.Accounts.Add(newAccount);
            }
            else
            {
                bool isFound = false;

                for (int i = 0; i < db.Accounts.Count; i++)
                {
                    if (db.Accounts[i].Id == account.Id)
                    {
                        db.Accounts[i] = account;
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    throw new Exception("Account not found");
                }
            }
            _storage.Save(db);
        }
    }
}

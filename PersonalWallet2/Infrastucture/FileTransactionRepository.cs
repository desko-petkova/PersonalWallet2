using PersonalWallet2.Domain.Entities;
using PersonalWallet2.Domain.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PersonalWallet2.Infrastucture
{
    public class FileTransactionRepository
    {
        private readonly FileStorage _storage;

        public FileTransactionRepository(FileStorage storage)
        {
            _storage = storage;
        }
        public void Save(Transaction transaction)
        {
            var db = _storage.Load();
            
            var newTransaction = new Transaction(
                db.NextId++,
                transaction.AccountId,
                transaction.Type,
                transaction.Amount,
                transaction.Date
                );
            db.Transactions.Add( newTransaction );

            _storage.Save(db);
        }
        public IReadOnlyList<Transaction> GetByAccountId(int acountId)
        {
            var db = _storage.Load();

            List<Transaction> result = new List<Transaction>();

            foreach (Transaction transaction in db.Transactions)
            {
                if( transaction.AccountId == acountId )
                result.Add( transaction );
            }
            return result;
        }
    }
}

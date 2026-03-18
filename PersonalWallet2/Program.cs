using PersonalWallet2.Application;
using PersonalWallet2.Application.Interfaces;
using PersonalWallet2.ConsoleUI;
using PersonalWallet2.Infrastucture;
namespace PersonalWallet2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new FileStorage("wallet.json");

            IAccountRepository accountRepo = new FileAccountRepository(storage);

            ITransactionRepository transactionRepo = new FileTransactionRepository(storage);

            var service = new WalletService(accountRepo, transactionRepo);

            var ui = new WalletConsoleUI(service);

            ui.Run();
        }
    }
}

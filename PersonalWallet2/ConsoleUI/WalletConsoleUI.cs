using PersonalWallet2.Application;
using PersonalWallet2.Domain.Enums;
using System.Collections.Concurrent;

namespace PersonalWallet2.ConsoleUI
{
    public class WalletConsoleUI
    {
        private readonly WalletService service;
        public WalletConsoleUI(WalletService service)
        {
            this.service = service;
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("======== Wallet System ==========");
                Console.WriteLine("1. Create account");
                Console.WriteLine("2. Add income");
                Console.WriteLine("3. Add expense");
                Console.WriteLine("4. Show accounts");
                Console.WriteLine("5. Show transactions");
                Console.WriteLine("0. Exit");

                Console.WriteLine("Choose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateAcount();
                        break;
                    case "2":
                        AddTransaction(TransactionType.Income);
                        break;
                    case "3":
                        AddTransaction(TransactionType.Expense);
                        break;
                    case "4":
                        ShowAccount();
                        break;
                    case "5":
                        ShowTransaction();
                        break;
                    case "0":
                        running = false;
                        break;
                }
            }

        }

        private void ShowTransaction()
        {
            throw new NotImplementedException();
        }

        private void ShowAccount()
        {
            throw new NotImplementedException();
        }

        private void AddTransaction(TransactionType income)
        {
            throw new NotImplementedException();
        }

        private void CreateAcount()
        {
            Console.Write("Enter account name:");
            string name = Console.ReadLine();



            Console.Write("Amount: ");
            string amountInput = Console.ReadLine();

            if (!decimal.TryParse(amountInput, out decimal amount))
            {
                Console.WriteLine("Invalid input!");
                return;
            }


        //Cash,
        //Bank,
        //DebitCart,
        //VitualCart,
        //SavingBank
        }
    }
}

        
    

using PersonalWallet2.Application;
using PersonalWallet2.Domain.Entities;
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
            var account = service.GetAllAccounts();
            if(account.Count == 0)
            {
                Console.WriteLine("Accounts not found");
            }
            foreach(var acc  in account)
            {
Console.WriteLine($"{acc.Id} | {acc.Name} | {acc.Type} | {acc.Balance.Amount}");
            }
            Console.ReadLine();
        }

        private void AddTransaction(TransactionType income)
        {
            throw new NotImplementedException();
        }

        private void CreateAcount()
        {
            Console.Write("Enter account name:");
            string name = Console.ReadLine();

            Console.WriteLine("Account type:");
            Console.WriteLine("Cash, 0:");
            Console.WriteLine("Bank, 1:");
            Console.WriteLine("DebitCart, 2:");
            Console.WriteLine("VitualCart, 3:");
            Console.WriteLine("SavingBank, 4:");
            Console.Write("Choose type:");
            string input = Console.ReadLine();
            int type;
            while(!int.TryParse(input, out type))
            {
                Console.WriteLine("Invalid input");
                Console.Write("Try again:");
                input = Console.ReadLine();
            }
            var typeAccount = (AccountType)type;

            Console.Write("Initial amount: ");
            string amountInput = Console.ReadLine();

            decimal amount;
            while (!decimal.TryParse(amountInput, out amount))
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Try again:");
                amountInput = Console.ReadLine();
            }
            try
            {
                service.CreateAccount(name, typeAccount, amount);
                Console.WriteLine("New account is created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}

        
    

using PersonalWallet2.Infrastucture;
namespace PersonalWallet2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new FileStorage("wallet.json");
        }
    }
}

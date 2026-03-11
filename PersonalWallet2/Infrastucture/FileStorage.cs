namespace PersonalWallet2.Infrastucture
{
    public class FileStorage
    {
        private readonly string path;

        public FileStorage(string path ="personalWallet.json")
        {
            this.path = path;
        }



    }
}

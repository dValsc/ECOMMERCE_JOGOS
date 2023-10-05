namespace ecommercejogos.Security
{
    public class Settings
    {
        private static string secret = "4aa5b4fbc2f9baafafcad2438437cad055f172a048ff42ebcf4e374a188091d9";

        public static string Secret
        {
            get => secret;
            set => secret = value;
        }

    }
}

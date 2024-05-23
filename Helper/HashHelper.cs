namespace AccountShop.Helper
{
    public class HashHelper
    {
        public static string Encode(string text)
        {
                text = BCrypt.Net.BCrypt.HashPassword(text);
            return text;
        }
        public static bool Decode(string text,string hash)
        {
            var result = BCrypt.Net.BCrypt.Verify(text,hash);
            return result;
        }
    }
}

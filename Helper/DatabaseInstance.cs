using AccountShop.Models;

namespace AccountShop.Helper
{
    public class DatabaseInstance
    {
        private static AccountShopContext INSTANCE = new AccountShopContext();
        public static AccountShopContext GetInstance()
        { 
            return INSTANCE;
        }
    }
}

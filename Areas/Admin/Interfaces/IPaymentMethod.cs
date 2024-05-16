namespace AccountShop.Areas.Admin.Interfaces
{
    public interface IPaymentMethod
    {
        public List<Models.Paymentmethod> Select();
        public Models.Paymentmethod Select(int id);
        public Models.Paymentmethod InsertToDatabase(Models.Paymentmethod method);
        public Models.Paymentmethod UpdateToDatabase(Models.Paymentmethod method);
        public bool Delete(int id);

    }
}

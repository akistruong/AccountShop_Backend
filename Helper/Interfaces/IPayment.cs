
namespace AccountShop.Helper.Interfaces
{
    public abstract class IPayment
    {
        public abstract Models.TblOrder VNPAY(Models.TblOrder order);
        public abstract Models.TblOrder MOMO(Models.TblOrder order);
        public abstract Models.TblOrder Paypal(Models.TblOrder order);
    }
}

using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.Business_Layer
{
    public class PaymentMethodBUS : IPaymentMethod
    {
        PaymentMethodDAO paymentMehodDAO;
        
        public PaymentMethodBUS(AccountShopContext context) { 
            paymentMehodDAO = new PaymentMethodDAO(context);   
        }   
        public bool Delete(int id)
        {
            return paymentMehodDAO.Delete(id);
        }

        public Paymentmethod InsertToDatabase(Paymentmethod method)
        {
            return paymentMehodDAO.Insert(method);
        }

        public List<Paymentmethod> Select()
        {
            return paymentMehodDAO.Select();    
        }

        public Paymentmethod Select(int id)
        {
            return paymentMehodDAO.Select(id);  
        }

        public Paymentmethod UpdateToDatabase(Paymentmethod method)
        {
            return paymentMehodDAO.Update(method);
        }
    }
}

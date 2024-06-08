using AccountShop.Helper;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.DataLayer
{
    public class PaymentMethodDAO
    {
        AccountShopContext context;

        public PaymentMethodDAO(AccountShopContext context)
        {
            this.context = context;
        }

        public List<Models.Paymentmethod> Select()
        {
            return context.Paymentmethods.ToList();
        }
        public Models.Paymentmethod Select(int id) {
            return context.Paymentmethods.FirstOrDefault(x=>x.MethodId ==id);
        }
        public Models.Paymentmethod Insert(Models.Paymentmethod model)
        {
            context.Paymentmethods.Add(model);
            context.SaveChanges();
            return model;
        }
        public Models.Paymentmethod Update(Models.Paymentmethod model) { 
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return model;
        }
        public bool Delete(int id)
        {
            var model = context.Paymentmethods.FirstOrDefault(x => x.MethodId == id);
            if(model != null)
            {
                context.Paymentmethods.Remove(model);
                return true;
            }
            return false;
        }
    }
}

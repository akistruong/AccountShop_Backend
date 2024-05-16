using AccountShop.Helper;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.DataLayer
{
    public class OrderDAO
    {
        AccountShopContext context = DatabaseInstance.GetInstance();
        public List<Models.TblOrder> Select()
        {
            return context.TblOrders.ToList();  
        }
        public Models.TblOrder Select(int id) {
            return context.TblOrders.Find(id);
        }
        public Models.TblOrder Insert(Models.TblOrder order)
        {
            context.TblOrders.Add(order);
            context.SaveChanges();
            return order;
        }
        public Models.TblOrder Update(Models.TblOrder order) { 
            context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return order;
        }
        public bool Delete(int id)
        {
            var order = context.TblOrders.Find(id);
            if (order != null)
            {
                order.DeletedAt = DateTime.Now;
                context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

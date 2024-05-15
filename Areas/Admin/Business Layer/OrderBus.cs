using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.Business_Layer
{
    public class OrderBus : IOrder
    {
        OrderDAO orderDAO;
        public OrderBus() {
            orderDAO = new OrderDAO(); 
                }   
        public TblOrder CreateOrder(TblOrder order)
        {
            return orderDAO.Insert(order);  
        }

        public bool Delete(int id)
        {
            return orderDAO.Delete(id); 
        }

        public List<TblOrder> Get()
        {
            return orderDAO.Select();
        }

        public TblOrder Get(int id)
        {
            return orderDAO.Select(id); 
        }

        public TblOrder UpdateOrder(TblOrder order)
        {
            return orderDAO.Update(order);  
        }
    }
}

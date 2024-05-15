namespace AccountShop.Areas.Admin.Interfaces
{
    public interface IOrder
    {
        public List<Models.TblOrder> Get();
        public Models.TblOrder Get(int id);
        public Models.TblOrder CreateOrder(Models.TblOrder order);
        public Models.TblOrder UpdateOrder(Models.TblOrder order);
        public bool Delete(int id);
    }
}

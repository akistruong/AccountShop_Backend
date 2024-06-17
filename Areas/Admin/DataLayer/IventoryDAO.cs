using AccountShop.Models;

namespace AccountShop.Areas.Admin.DataLayer
{
    public class IventoryDAO
    {
        AccountShopContext context;

        public IventoryDAO(AccountShopContext context)
        {
            this.context = context;
        }
        public List<Models.Iventory> Select()
        {
            return context.Iventories.ToList(); 
        }
        public List<Models.Iventory> SelectByProductID(string id)
        {
            return context.Iventories.Where(x=>x.ProductID==id).ToList();
        }
        public List<Models.Iventory> SelectByProductBranchID(int id)
        {
            return context.Iventories.Where(x => x.BranchID == id).ToList();
        }
        public Models.Iventory Insert(Models.Iventory iventory)
        {
            context.Entry(iventory).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();
            return iventory;
        }
        public async Task<Models.Iventory> InsertAsync(Models.Iventory iventory)
        {
            context.Entry(iventory).State = Microsoft.EntityFrameworkCore.EntityState.Added;
          await   context.SaveChangesAsync();
            return iventory;
        }
        public Models.Iventory Update(Models.Iventory iventory)
        {
            context.Entry(iventory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return iventory;
        }
        public bool Delete(Models.Iventory iventory)
        {
            context.Entry(iventory).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
            return true;
        }
    }
}

using AccountShop.Models;

namespace AccountShop.Areas.Admin.DataLayer
{
    public class BranchDAO
    {

        AccountShopContext context;

        public BranchDAO(AccountShopContext context)
        {
            this.context = context;
        }
        public List<Branch> Select() {
            return context.Branches.ToList();
        }
        public Models.Branch Select(int id) {
            return context.Branches.Find(id);
        }
        public Models.Branch Insert(Models.Branch branch) {
            context.Entry(branch).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();
            return branch;
        }
        public Models.Branch Update(Models.Branch branch)
        {
            context.Entry(branch).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return branch;
        }
        public bool Delete(Models.Branch branch)
        {
            context.Entry(branch).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
            return true;
        }
    }
}

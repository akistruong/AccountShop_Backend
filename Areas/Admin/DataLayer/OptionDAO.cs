using AccountShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountShop.Areas.Admin.DataLayer
{
    public class OptionDAO
    {
        AccountShopContext context;

        public OptionDAO(AccountShopContext context)
        {
            this.context = context;
        }
        public List<Option> Select() { 
            return context.Options.ToList();
        }
        public Option Select(string id) {

            return context.Options.FirstOrDefault(x => x.OptionID == id)??null;
        }
        public Option Insert(Option option)
        {
            context.Options.Add(option);
            context.SaveChanges();
            return option;
        }
        public Option Update(Option option) { 
            context.Entry(option).State = Microsoft.EntityFrameworkCore.EntityState.Modified;   
            context.SaveChanges();
            return option;
        }
        public bool Delete(string id)
        {
            var option = context.Options.Find(id);
            if (option != null)
            {
                context.Options.Remove(option);
                context.SaveChanges();
                return true;
            }
            return false;

        }
        
        public List<Option> SelectOptionByProductID(string productID) { 
            var options = context.Options.Where(x=>x.ProductID == productID).Include(x=>x.OptionValues).ToList();
            return options;
        }


    }
}

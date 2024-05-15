using AccountShop.Helper;
using AccountShop.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountShop.DataLayer
{
    public class ProductDAO
    {
            AccountShopContext context = DatabaseInstance.GetInstance();
        public List<Models.Product> Select()
        {
            var products = context.Products.ToList();
            return products;
        }
        public Models.Product SelectByID(string id) {
            var product= context.Products.FirstOrDefault(x=>x.ProductId==id);
            return product;
        }
        public Models.Product Insert(Models.Product product) { 
            var result = context.Products.Add(product);
            context.SaveChanges();
            return product;
        }
        public Models.Product Update(Models.Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
            return product;
        }
        public bool Delete(string id)
        {
            try
            {
                var product = context.Products.FirstOrDefault(x => x.ProductId == id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }catch (Exception ex) { 
                return false;
            }

        }
    }
}

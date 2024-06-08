using AccountShop.Helper;
using AccountShop.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountShop.Areas.Admin.DataLayer
{
    public class ProductDAO
    {
        AccountShopContext context ;

        public ProductDAO(AccountShopContext context)
        {
            this.context = context;
        }

        public List<Product> Select()
        {
            var products = context.Products.ToList();
            return products;
        }
        public Product SelectByID(string id)
        {
            var product = context.Products.FirstOrDefault(x => x.ProductId == id);
            return product;
        }
        public Product Insert(Product product)
        {
            var result = context.Products.Add(product);
            context.SaveChanges();
            return product;
        }
        public Product Update(Product product)
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
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}

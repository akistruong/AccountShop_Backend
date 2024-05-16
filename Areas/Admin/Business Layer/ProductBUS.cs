using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Helper;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.Business_Layer
{
    public class ProductBUS : IProduct
    {
        private ProductDAO _productDAO;
        public ProductBUS()
        {
            _productDAO = new ProductDAO();
        }
        public async Task<bool> DeleteProduct(string productID)
        {
            try
            {
                var product  =_productDAO.SelectByID(productID);    
                if (product != null&&product.ProductImage!=null) {
                var path = "wwwroot/source/products/"+product.ProductId+"//"+product.ProductImage;
                var fileManager = new FileManager();
                    await fileManager.Delete(path);
                }
                var result = _productDAO.Delete(productID);
                return result;
            }catch (Exception ex) {
                throw ex;
                    
                    }
        }

        public List<Product> GetAllProducts()
        {
            var products = _productDAO.Select();
            return products;
        }

        public Product GetProductById(string productId)
        {
            var product = _productDAO.SelectByID(productId);    
            return product;
        }

        public Product InsertProduct(Product product)
        {
            var result = _productDAO.Insert(product);
            return result;
                
                }

        public Product PutProduct(Product product)
        {
           var result = _productDAO.Update(product);    
            return result;  
        }
    }
}

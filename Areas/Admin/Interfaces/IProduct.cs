namespace AccountShop.Areas.Admin.Interfaces
{
    public interface IProduct
    {
        public List<Models.Product> GetAllProducts();
        public Models.Product GetProductById(string productId);
        public Models.Product PutProduct(Models.Product product);
        public Models.Product InsertProduct(Models.Product product);
        public bool DeleteProduct(string productID);
    }
}

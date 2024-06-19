using AccountShop.Models;

namespace AccountShop.Helper
{
    public class OrderItemHelper
    {
        AccountShopContext context;

        public OrderItemHelper(AccountShopContext context)
        {
            this.context = context;
        }

        public List<Models.Variant> GetVariantsByOrderItems(List<Models.Orderdetail> orderitems)
        {
           if(orderitems!=null&&orderitems.Count>0)
            {
                var variants = new List<Models.Variant>();
                foreach (var item in orderitems)
                {
                    var variant = context.Variants.FirstOrDefault(x => x.VariantId == item.VariantId);

                    if (variant != null)
                    {
                        variants.Add(variant);
                    }
                }
                return variants;
            }
            return null;
        }
    }
}

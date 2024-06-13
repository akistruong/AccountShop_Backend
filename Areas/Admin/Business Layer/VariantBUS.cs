﻿using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.Business_Layer
{
    public class VariantBUS : IVariant
    {
        VariantDAO variantDAO;

        public VariantBUS(AccountShopContext _context) { 
            variantDAO = new VariantDAO(_context);
        }
        public bool Delete(int id)
        {
            return variantDAO.Delete(id);
        }
        public Models.Variant GetVariantByOptionValue(List<string> ids)
        {
            return variantDAO.SelectVariantByAttribute(ids);    
        }
        public List<Variant> Get()
        {
            return variantDAO.Select();
        }

        public Variant Get(int id)
        {
            return variantDAO.Select(id);
        }
        public List<Models.Variant> GetByProduct(string id)
        {
            return variantDAO.SelectVariantsByProduct(id);  
        }

        public Variant InsertToDatabase(Variant variant)
        {
            return variantDAO.Insert(variant);    
        }

        public Variant UpdateToDatabase(Variant variant)
        {
            return variantDAO.Update(variant);
        }

    }
}

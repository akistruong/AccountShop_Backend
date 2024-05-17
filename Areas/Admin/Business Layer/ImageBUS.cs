using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.Business_Layer
{
    public class ImageBUS : IImage
    {
        ImageDAO imageDAO;
        public ImageBUS() {
            imageDAO = new ImageDAO();  
        }   
        public bool Delete(int id)
        {
            return imageDAO.Delete(id);
        }

        public TblImage InsertToDatabase(TblImage image)
        {
            imageDAO.Insert(image);
            return image;
        }

        public List<TblImage> Select()
        {
            return imageDAO.Select();
        }

        public TblImage Select(int id)
        {
            return imageDAO.Select(id);
        }

        public List<TblImage> SelectImagesByProduct(string id)
        {
            return imageDAO.GetImagesByProduct(id);
        }

        public TblImage UpdateToDatabase(TblImage image)
        {
            return imageDAO.Update(image);
        }
    }
}

using Sattim.DataAccess.Abstract;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;

namespace Sattim.DataAccess.Concrete
{
    public class PictureRepository : IPictureRepository
    {
        public Picture CreatePicture(Picture picture)
        {
            using (var pictureDbContext = new UserDbContext())
            {

                pictureDbContext.Pictures.Add(picture);
                pictureDbContext.SaveChanges();
                return picture;
            }
        }

        public void DeletePicture(int id)
        {
            using (var pictureDbContext = new UserDbContext())
            {
                var deletedPicture = GetPictureById(id);
                pictureDbContext.Pictures.Remove(deletedPicture);
                pictureDbContext.SaveChanges();
            }
        }
        public void DeletePictureByProId(int id)
        {
            using (var pictureDbContext = new UserDbContext())
            {
                var deletedPicture = pictureDbContext.Pictures.Where(x => x.productId == id);
                foreach (var item in deletedPicture)
                {
                    pictureDbContext.Pictures.Remove(item);
                }
               
                pictureDbContext.SaveChanges();
            }
        }

        public List<Picture> GetAllPicture()
        {
           using ( var pictureDbContext = new UserDbContext())
            {
                return pictureDbContext.Pictures.ToList();
            }
        }

        public Picture GetPictureById(int id)
        {
            using (var pictureDbContext = new UserDbContext())
            {
                return pictureDbContext.Pictures.Find(id);
            }
        }

        public List<Picture> GetPictureByProductId(int id)
        {
            using (var pictureDbContext = new UserDbContext())
            {
                return pictureDbContext.Pictures.Where(x => x.productId == id).ToList();
            }
        }

        public Picture UpdatePicture(Picture picture)
        {
            using (var pictureDbContext = new UserDbContext())
            {

                pictureDbContext.Pictures.Update(picture);
                pictureDbContext.SaveChanges();
                return picture;
            }
        }
    }
}

using Sattim.Business.Abstract;
using Sattim.DataAccess.Abstract;
using Sattim.DataAccess.Concrete;
using Sattim.Entities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace Sattim.Business.Concrete
{
    public class PictureManager : IPictureService
    {

        private IPictureRepository _pictureRepository;

        public PictureManager(IPictureRepository  pictureRepository)
        {
             _pictureRepository = pictureRepository;
        }

        public Picture CreatePicture (Picture picture)
        {
            return _pictureRepository.CreatePicture(picture);
        }

        public void DeletePicture(int id)
        {
           _pictureRepository.DeletePicture(id);
        }

        public List<Picture> GetAllPicture()
        {
            return _pictureRepository.GetAllPicture();
        }
        public List<Picture> GetPictureByProductId(int id)
        {
            return _pictureRepository.GetPictureByProductId(id);
        }
        public Picture GetPictureById(int id)
        {
            return _pictureRepository.GetPictureById(id);
        }

        public Picture UpdatePicture(Picture picture)
        {
            return _pictureRepository.UpdatePicture(picture);
        }
        public void DeletePictureByProId(int id)
        {
             _pictureRepository.DeletePictureByProId(id);
        }

    }
}

﻿using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sattim.Business.Abstract
{
    public interface IPictureService
    {

        List<Picture> GetAllPicture();
        Picture GetPictureById(int id);

        List<Picture> GetPictureByProductId(int id);
        Picture CreatePicture(Picture picture);

        Picture UpdatePicture(Picture picture);
        void DeletePicture(int id);
        void DeletePictureByProId(int id);
    }
}

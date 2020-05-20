using ImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Data
{
    public interface IImage
    {
        IEnumerable<Image> GetAll();
        IEnumerable<Image> GetWithTag(string tag);
        Image GetById(int? id);
        void AddImage(Image newImage);
        void DeleteImage(int id);
    }
}

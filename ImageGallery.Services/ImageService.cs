using ImageGallery.Data;
using ImageGallery.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public class ImageService : IImage
    {
        private readonly ImageGalleryDbContext _ctx;
        public ImageService(ImageGalleryDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddImage(Image newImage)
        {
            throw new NotImplementedException();
        }

        public void DeleteImage(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Image> GetAll()
        {
            // возвращаем все картинки с их тегами
            return _ctx.Images.Include(img => img.Tags);
        }

        public Image GetById(int id)
        {
            return _ctx.Images.Find(id);
        }

        public IEnumerable<Image> GetWithTag(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }
    }
}

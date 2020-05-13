using ImageGallery.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ImageGallery.Data
{
    public class ImageGalleryDbContext : DbContext
    {
        public ImageGalleryDbContext(DbContextOptions options) : base(options) { }
        DbSet<Image> Images { get; set; }
        DbSet<Tag> Tags{ get; set; }
    }
}

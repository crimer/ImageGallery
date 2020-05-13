using ImageGallery.Data.Models;
using System.Collections.Generic;

namespace ImageGallery.ViewModels
{
    public class GalleryVM
    {
        public IEnumerable<Image> Images { get; set; }
        public string SearchQuery { get; set; }
    }
}

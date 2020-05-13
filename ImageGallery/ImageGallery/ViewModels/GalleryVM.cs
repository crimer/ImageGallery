using ImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.ViewModels
{
    public class GalleryVM
    {
        public IEnumerable<Image> Images { get; set; }
        public string SearchQuery { get; set; }
    }
}

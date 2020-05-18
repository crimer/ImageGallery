using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.ViewModels
{
    public class UploadVM
    {
        public string Title { get; set; }
        public string Tags { get; set; }
        public IFormFile ImageUploaded { get; set; }
    }
}

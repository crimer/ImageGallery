using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.ViewModels
{
    public class UploadVM
    {
        [Required(ErrorMessage = "Write some title")]
        public string Title { get; set; }
        public string Tags { get; set; }
        [Required(ErrorMessage = "Upload image plaese")]
        public IFormFile ImageUploaded { get; set; }
    }
}

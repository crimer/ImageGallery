using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ImageGallery.ViewModels
{
    public class UploadVM
    {
        [Required(ErrorMessage = "Write some title")]
        [DisplayName("Image Title")]
        public string Title { get; set; }
        [DisplayName("List of Tags")]
        public string Tags { get; set; }
        [Required(ErrorMessage = "Upload image plaese")]
        public IFormFile ImageUploaded { get; set; }
    }
}

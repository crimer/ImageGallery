using ImageGallery.Data;
using ImageGallery.Data.Models;
using ImageGallery.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImage _imageService;

        public ImageController(IImage imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Upload()
        {
            var vm = new UploadVM();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewImage(UploadVM uploadVM)
        {
            Image newImage = new Image()
            {
                Title = uploadVM.Title,
                Created = DateTime.Now,
                ImageUrl = "/images/gallery/" + uploadVM.ImageUploaded.FileName
            };
            if (uploadVM.ImageUploaded != null && uploadVM.ImageUploaded.Length > 0)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\gallery\\", uploadVM.ImageUploaded.FileName);

                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await uploadVM.ImageUploaded.CopyToAsync(fStream);
                }
            }
            _imageService.AddImage(newImage);

            TempData["message"] = $"Image \"{uploadVM.Title}\" has benn added to gallery";
            return RedirectToAction("Index","Gallery");
        }
    }
}

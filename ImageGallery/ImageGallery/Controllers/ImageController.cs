using ImageGallery.Data;
using ImageGallery.Data.Models;
using ImageGallery.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImageGallery.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImage _imageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(IImage imageService, IWebHostEnvironment webHost)
        {
            _imageService = imageService;
            _webHostEnvironment = webHost;
        }
        [HttpGet]
        public IActionResult Upload()
        {
            //Image image = _imageService.GetById(id);
            //if(!image)
            UploadVM vm = new UploadVM();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadNewImage(UploadVM uploadVM)
        {
            if (!ModelState.IsValid)
            {
                return View(uploadVM);
            }
            Image newImage = new Image()
            {
                Title = uploadVM.Title,
                Created = DateTime.Now,
                ImageUrl = "/images/gallery/" + uploadVM.ImageUploaded.FileName
            };
            if (uploadVM.ImageUploaded != null && uploadVM.ImageUploaded.Length > 0)
            {
                string path = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot\\images\\gallery\\", uploadVM.ImageUploaded.FileName);

                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await uploadVM.ImageUploaded.CopyToAsync(fStream);
                }
            }
            _imageService.AddImage(newImage);

            TempData["message"] = $"Image \"{uploadVM.Title}\" has benn added to gallery";
            return RedirectToAction("Index", "Gallery");
        }

        [HttpPost]
        public IActionResult DeleteImage(int id)
        {
            _imageService.DeleteImage(id);
            return RedirectToAction("Index", "Gallery");
        }

        [HttpGet]
        public async Task<IActionResult> EditImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Image image = _imageService.GetById(id);
            
            if(image != null)
                return RedirectToAction("Index", "Gallery");

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditImage(UploadVM uploadVM)
        {
            return RedirectToAction("Index", "Gallery");
        }
    }
}

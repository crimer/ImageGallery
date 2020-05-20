using ImageGallery.Data;
using ImageGallery.Data.Models;
using ImageGallery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;
        public GalleryController(IImage imageServece)
        {
            _imageService = imageServece;
        }
        [HttpGet]
        public IActionResult Index()
        {
            // заполнил список картинок
            var imageList = _imageService.GetAll();

            // заполнил ViewModel
            var model = new GalleryVM()
            {
                Images = imageList,
                SearchQuery = ""
            };

            // вернул в представление ViewModel
            return View(model);
        }
        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            Image image = _imageService.GetById(id);
            if(image == null)
            {
                return RedirectToAction("Index");
            }
            DetailVM vm = new DetailVM(image);
            return View(vm);
        }
    }
}

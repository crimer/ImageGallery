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
        public IActionResult Detail(int id)
        {
            Image image = _imageService.GetById(id);
            DetailVM vm = new DetailVM(image);
            return View(vm);
        }
    }
}

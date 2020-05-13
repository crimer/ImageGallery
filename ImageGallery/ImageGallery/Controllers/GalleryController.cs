using ImageGallery.Data.Models;
using ImageGallery.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            // создал пустые списки тэгов
            List<Tag> hikingTags = new List<Tag>();
            List<Tag> cityTags = new List<Tag>();

            // создал три тэга
            var tag1 = new Tag() { Id = 0, Description = "Boston" };
            var tag2 = new Tag() { Id = 1, Description = "New York" };
            var tag3 = new Tag() { Id = 2, Description = "Adventure" };

            // заполнил списки тегов
            hikingTags.Add(tag3);
            cityTags.AddRange(new List<Tag>(){ tag1,tag2});

            // заполнил список картинок
            List<Image> imageList = new List<Image>()
            {
                new Image()
                {
                    Title = "Hiking Trip",
                    ImageUrl = "https://images.unsplash.com/photo-1551632811-561732d1e306?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80",
                    Tags = hikingTags,
                    Created = DateTime.Now
                },
                new Image()
                {
                    Title = "On The Trail",
                    ImageUrl = "https://images.unsplash.com/photo-1480714378408-67cf0d13bc1b?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80",
                    Tags = cityTags,
                    Created = DateTime.Now
                },
                new Image()
                {
                    Title = "Downtown",
                    ImageUrl = "https://images.unsplash.com/Ys-DBJeX0nE.JPG?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80",
                    Tags = cityTags,
                    Created = DateTime.Now
                }
            };

            // заполнил ViewModel
            var model = new GalleryVM()
            {
                Images = imageList,
                SearchQuery = ""
            };

            // вернул в представление ViewModel
            return View(model);
        }

    }
}

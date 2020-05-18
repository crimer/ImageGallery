using ImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageGallery.ViewModels
{
    public class DetailVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Tags { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Url { get; set; }
        public DetailVM(Image image)
        {
            Id = image.Id;
            Title = image.Title;
            Tags = image.Tags.Select(t => t.Description).ToList();
            CreatedOn = image.Created;
            Url = image.ImageUrl;
        }


    }
}

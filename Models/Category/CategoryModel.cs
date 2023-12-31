using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS23_Carousel.Models
{
    public class CategoryModel
    {
        public CategoryModel(string description)
        {
            Id = Guid.NewGuid();
            Description = description;
            IsActive = true;
        }

        public CategoryModel()
        {
            
        }

        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS23_Carousel.Models;

namespace AMS23_BordaDourada.Models
{
    public class ProductModel
    {
        public ProductModel(string description)
        {
            Id = Guid.NewGuid();
            Description = description;
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
using AMS23_BordaDourada.Models.Interfaces;
using AMS23_Carousel.Data.Repository;
using AMS23_Carousel.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS23_BordaDourada.Data.Repository
{
    public class CategoryRepository : RepositoryBase<CategoryModel, Guid>,ICategoryRepository
    {
        public CategoryRepository(ApplicationDataContext applicationDataContext) : base(applicationDataContext)
        {
            
        }

    }
}
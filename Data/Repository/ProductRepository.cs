using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS23_BordaDourada.Models;
using AMS23_BordaDourada.Models.Interfaces;
using AMS23_Carousel.Data.Repository;

namespace AMS23_BordaDourada.Data.Repository
{
    public class ProductRepository : RepositoryBase<ProductModel, Guid>, IProductRepository
    {
        public ProductRepository(ApplicationDataContext applicationDataContext) : base(applicationDataContext)
        {
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS23_BordaDourada.Models.Interfaces;
using AMS23_Carousel.Data.Repository;
using AMS23_Carousel.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS23_BordaDourada.Data.Repository
{
    public class RepositoryBase<TEntity, Tkey> : IRepositoryBase<TEntity, Tkey> where TEntity : class
    {
        private readonly ApplicationDataContext _applicationDataContext;
        protected readonly DbSet<TEntity> _entity;
        public RepositoryBase(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
            _entity = _applicationDataContext.Set<TEntity>();
            
        }
        public void Add(TEntity entity)
        {
            _entity.Add(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _applicationDataContext.SaveChangesAsync() > 0;
        }

        public void Delete(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _applicationDataContext.Entry(entity).State = EntityState.Modified;
        }


        public TEntity Get(Guid id)
        {
            return _entity.Find(id) ?? throw new Exception("Entity not found");
        }
    }
}
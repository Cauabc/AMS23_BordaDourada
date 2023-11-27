using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS23_BordaDourada.Models.Interfaces
{
    public interface IRepositoryBase<TEntity, Tkey> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<bool> SaveChangesAsync();
    }
}
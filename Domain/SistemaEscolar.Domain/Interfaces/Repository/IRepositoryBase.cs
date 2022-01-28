using SistemaEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TContext, TEntity, TIdentity>
        where TEntity   : EntityBase<TIdentity>
        where TContext  : IUnitOfWork<TContext>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Exists(int id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
    }
}

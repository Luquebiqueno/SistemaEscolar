using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Repository.Repositories
{
    public class RepositoryBase<TContext, TEntity, TIdentity>  : IRepositoryBase<TContext, TEntity, TIdentity>
                                               where TEntity   : EntityBase<TIdentity>
                                               where TContext  : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        public IUnitOfWork<TContext> UnitOfWork { get; }
        protected DbSet<TEntity> _dbSet => ((DbContext)UnitOfWork).Set<TEntity>();

        #endregion

        #region [ Construtores ]

        public RepositoryBase(IUnitOfWork<TContext> unitOfWork) => this.UnitOfWork = unitOfWork;

        #endregion

        #region [ Métodos ]

        public virtual TEntity Create(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

        public virtual void Delete(int id)
        {
            try
            {
                TEntity entity = Exists(id);
                if (entity != null)
                    _dbSet.Remove(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual TEntity Exists(int id)
        {
            try
            {
                return _dbSet.SingleOrDefault(x => x.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual TEntity GetById(int id)
        {
            try
            {
                return _dbSet.SingleOrDefault(x => x.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    var result = _dbSet.Attach(entity);
                    result.State = EntityState.Modified;
                    result.Property(x => x.UsuarioCadastro).IsModified = false;
                    result.Property(x => x.DataCadastro).IsModified = false;

                    return entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet.SingleOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

        #endregion
    }
}

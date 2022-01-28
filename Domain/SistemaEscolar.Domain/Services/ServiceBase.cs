using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Domain.Interfaces.Repository;
using SistemaEscolar.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Services
{
    public class ServiceBase<TContext, TEntity, TIdentity>  : IServiceBase<TContext, TEntity, TIdentity>
                                            where TEntity   : EntityBase<TIdentity>
                                            where TContext  : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        protected readonly IRepositoryBase<TContext, TEntity, TIdentity> _repository;

        #endregion

        #region [ Construtores ]

        public ServiceBase(IRepositoryBase<TContext, TEntity, TIdentity> repository)
        {
            this._repository = repository;
        }

        #endregion

        #region [ Métodos ]

        public virtual TEntity Create(TEntity entity)
        {
            entity.AtualizarDataCadastro();
            _repository.Create(entity);

            return entity;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            entity.AtualizarDataCadastro();
            await _repository.CreateAsync(entity);

            return entity;
        }

        public virtual void Delete(int id) => _repository.Delete(id);

        public virtual IEnumerable<TEntity> GetAll() => _repository.GetAll();

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _repository.GetAllAsync();

        public virtual TEntity GetById(int id) => _repository.GetById(id);

        public virtual async Task<TEntity> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public virtual TEntity Update(TEntity entity)
        {
            entity.AtualizarDataAlteracao();

            _repository.Update(entity);

            return entity;
        }

        #endregion
    }
}

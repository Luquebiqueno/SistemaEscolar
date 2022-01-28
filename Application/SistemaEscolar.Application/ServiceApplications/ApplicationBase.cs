using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Domain.Interfaces.Application;
using SistemaEscolar.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Application.ServiceApplications
{
    public class ApplicationBase<TContext, TEntity, TIdentity>  : IApplicationBase<TContext, TEntity, TIdentity>
                                                 where TEntity  : EntityBase<TIdentity>
                                                 where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        protected readonly IServiceBase<TContext, TEntity, TIdentity> _service;
        protected readonly IUnitOfWork<TContext> _unitOfWork;

        #endregion

        #region [ Construtores ]

        public ApplicationBase(IUnitOfWork<TContext> unitOfWork, IServiceBase<TContext, TEntity, TIdentity> service)
        {
            this._service = service;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region [ Métodos ]

        public virtual TEntity Create(TEntity entity)
        {
            _service.Create(entity);
            _unitOfWork.Commit();

            return entity;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _service.CreateAsync(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public virtual void Delete(int id)
        {
            _service.Delete(id);
            _unitOfWork.Commit();
        }

        public virtual IEnumerable<TEntity> GetAll() => _service.GetAll();

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _service.GetAllAsync();

        public virtual TEntity GetById(int id) => _service.GetById(id);

        public virtual async Task<TEntity> GetByIdAsync(int id) => await _service.GetByIdAsync(id);

        public virtual TEntity Update(TEntity entity)
        {
            _service.Update(entity);
            _unitOfWork.Commit();

            return entity;
        }

        #endregion
    }
}

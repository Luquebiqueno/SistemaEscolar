using SistemaEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Interfaces.Application
{
    public interface IUsuarioApplication<TContext> : IApplicationBase<TContext, Usuario, int>
                                    where TContext : IUnitOfWork<TContext>
    {
        Usuario GetUsuarioLogado();
        Usuario UpdateUsuario(int id, Usuario entity);
    }
}

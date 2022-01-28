using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface IViewModel<out TEntity>
    {
        TEntity Model();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Dto
{
    public class AlunoDto
    {
        #region [ Propriedades ]

        public string Nome { get; set; }
        public decimal Media { get; set; }
        public string Status { get; set; }

        #endregion
    }
}

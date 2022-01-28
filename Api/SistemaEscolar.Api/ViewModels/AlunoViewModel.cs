using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;

namespace SistemaEscolar.Api.ViewModels
{
    public class AlunoViewModel : IViewModel<Aluno>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long? Telefone { get; set; }
        public decimal Media { get; set; }

        public Aluno Model()
        {
            return new Aluno(this.Id, this.Nome, this.Telefone, this.Media);
        }
    }
}

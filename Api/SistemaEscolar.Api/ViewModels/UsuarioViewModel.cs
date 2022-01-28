using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;

namespace SistemaEscolar.Api.ViewModels
{
    public class UsuarioViewModel : IViewModel<Usuario>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }

        public Usuario Model()
        {
            return new Usuario(this.Id, this.Nome, this.Login);
        }
    }
}

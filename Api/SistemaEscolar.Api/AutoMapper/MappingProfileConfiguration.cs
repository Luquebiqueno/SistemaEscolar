using AutoMapper;
using SistemaEscolar.Api.ViewModels;
using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Api.AutoMapper
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Usuario, UsuarioViewModel>()
            .ReverseMap();

            CreateMap<Aluno, AlunoViewModel>()
            .ReverseMap();
        }
    }
}

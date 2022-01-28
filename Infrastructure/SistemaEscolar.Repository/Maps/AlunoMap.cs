using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Repository.Maps
{
    public class AlunoMap : EntityBaseMap<Aluno, int>
    {
        protected override void ConfigurarMapeamento(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno", "dbo");
            builder.Property(x => x.Id).HasColumnName("AlunoId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(128).IsRequired();
            builder.Property(x => x.Telefone).HasColumnName("Telefone").HasColumnType("bigint");
            builder.Property(x => x.Media).HasColumnName("Media").HasColumnType("decimal(4,2)").IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.UsuarioCadastro).HasColumnName("UsuarioCadastro").HasColumnType("int").IsRequired();
            builder.Property(x => x.DataAlteracao).HasColumnName("DataAlteracao").HasColumnType("datetime");
            builder.Property(x => x.UsuarioAlteracao).HasColumnName("UsuarioAlteracao").HasColumnType("int");
            builder.Property(x => x.Ativo).HasColumnName("Ativo").HasColumnType("bit").IsRequired();
        }
    }
}

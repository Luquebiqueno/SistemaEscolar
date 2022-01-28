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
    public class UsuarioMap : EntityBaseMap<Usuario, int>
    {
        protected override void ConfigurarMapeamento(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "dbo");
            builder.Property(x => x.Id).HasColumnName("UsuarioId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(128).IsRequired();
            builder.Property(x => x.Login).HasColumnName("Login").HasColumnType("varchar").HasMaxLength(128).IsUnicode().IsRequired();
            builder.Property(x => x.Senha).HasColumnName("Senha").HasColumnType("varchar").HasMaxLength(400).IsUnicode().IsRequired();
            builder.Property(x => x.RefreshToken).HasColumnName("RefreshToken").HasColumnType("varchar").HasMaxLength(500).IsUnicode();
            builder.Property(x => x.RefreshTokenExpiryTime).HasColumnName("RefreshTokenExpiryTime").HasColumnType("datetime").IsUnicode();
            builder.Property(x => x.Ativo).HasColumnName("Ativo").HasColumnType("bit").IsRequired();

            builder.Ignore(x => x.DataCadastro);
            builder.Ignore(x => x.UsuarioCadastro);
            builder.Ignore(x => x.DataAlteracao);
            builder.Ignore(x => x.UsuarioAlteracao);
        }
    }
}

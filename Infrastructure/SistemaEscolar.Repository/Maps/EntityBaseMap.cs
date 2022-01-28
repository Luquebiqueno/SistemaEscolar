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
    public abstract class EntityBaseMap<TEntity, TIdentity> : IEntityTypeConfiguration<TEntity>
                                            where TIdentity : struct
                                            where TEntity   : EntityBase<TIdentity>
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ativo)
                   .IsRequired();

            builder.Property(x => x.UsuarioCadastro)
                   .IsRequired();

            builder.Property(x => x.DataCadastro)
                   .IsRequired();

            builder.Property(x => x.UsuarioAlteracao);
            builder.Property(x => x.DataAlteracao);

            ConfigurarMapeamento(builder);
        }

        protected abstract void ConfigurarMapeamento(EntityTypeBuilder<TEntity> builder);

    }
}

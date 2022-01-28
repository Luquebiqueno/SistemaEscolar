using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Repository.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Repository.Context
{
    public class SistemaEscolarContext : ContextBase<SistemaEscolarContext>
    {
        public SistemaEscolarContext(DbContextOptions<SistemaEscolarContext> options) : base(options) { }

        public new int Commit() => this.SaveChanges();
        public new async Task<int> CommitAsync() => await this.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
        }
    }
}

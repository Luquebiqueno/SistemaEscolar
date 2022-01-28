using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Repository.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Repository.Context
{
    public class ContextBase<TContext> : DbContext, IUnitOfWork<TContext>
                        where TContext : DbContext
    {
        protected ContextBase(DbContextOptions<TContext> options) : base(options) { }

        protected virtual void RegisterMappings(ModelBuilder modelBuilder, Assembly assembly)
        {
            var typesToRegister = assembly.GetTypes()
                    .Where(type => !string.IsNullOrEmpty(type.Namespace)
                    && type.BaseType != null && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityBaseMap<,>));

            foreach (Type type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
        public int Commit() => SaveChanges();
        public async Task<int> CommitAsync() => await SaveChangesAsync();
    }
}

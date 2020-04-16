using Microsoft.EntityFrameworkCore;
using PatinhasMimadas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess
{
    public class GenericDataAccess<TEntity> : IGenericDataAccess<TEntity> where TEntity : class
    {
        public async Task<TEntity> Get(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                object[] key = { id };
                return await context.Set<TEntity>().FindAsync(key);
            };
        }

        public async Task<IList<TEntity>> GetAll()
        {
            using (var context = new PatinhasMimadasContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            };
        }

        public async Task Add(TEntity entity)
        {
            using (var context = new PatinhasMimadasContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}

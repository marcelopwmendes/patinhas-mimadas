using Microsoft.EntityFrameworkCore;
using PatinhasMimadas.Data;
using PatinhasMimadas.DataAccess.Interfaces;
using PatinhasMimadas.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess
{
    public class ServiceDataAccess : IServiceDataAccess
    {
        public async Task Add(ServiceDataAccessModel model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.Service.Add(new Service
                {
                    Id = model.Id,
                    Name = model.Name,
                    Price = model.Price
                });
                await context.SaveChangesAsync().ConfigureAwait(false);
            };
        }

        public async Task<ServiceDataAccessModel> Get(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                Service model = await context.Service
                    .Where(e => e.Id == id).SingleOrDefaultAsync();

                if (model != null)
                {
                    return new ServiceDataAccessModel
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Price = model.Price
                    };
                }

                return null;
            };
        }

        public async Task<IList<ServiceDataAccessModel>> GetAll()
        {
            using (var context = new PatinhasMimadasContext())
            {
                return await context.Service
                    .Select(e => new ServiceDataAccessModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Price = e.Price
                    }).ToListAsync().ConfigureAwait(false);
            };
        }

        public async Task Update(ServiceDataAccessModel model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.Service
                    .Update(new Service
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Price = model.Price
                    });

                await context.SaveChangesAsync().ConfigureAwait(false);
            };
        }

        public async Task Delete(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                Service model = context.Service.Where(e => e.Id == id).SingleOrDefault();

                if (model != null)
                {
                    context.Service.Remove(model);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }

            };
        }
    }
}

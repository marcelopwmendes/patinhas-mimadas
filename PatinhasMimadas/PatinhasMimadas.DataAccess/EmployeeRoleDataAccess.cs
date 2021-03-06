﻿using Microsoft.EntityFrameworkCore;
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
    public class EmployeeRoleDataAccess : IEmployeeRoleDataAccess
    {
        public async Task Add(EmployeeRoleDataAccessModel model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.EmployeeRole.Add(new EmployeeRole
                {
                    Id = model.Id,
                    Name = model.Name
                });
                await context.SaveChangesAsync().ConfigureAwait(false);
            };
        }

        public async Task<EmployeeRoleDataAccessModel> Get(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                EmployeeRole model = await context.EmployeeRole
                    .Where(e => e.Id == id).SingleOrDefaultAsync();

                if (model != null)
                {
                    return new EmployeeRoleDataAccessModel
                    {
                        Id = model.Id,
                        Name = model.Name
                    };
                }

                return null;
            };
        }

        public async Task<IList<EmployeeRoleDataAccessModel>> GetAll()
        {
            using (var context = new PatinhasMimadasContext())
            {
                return await context.EmployeeRole
                    .Select(e => new EmployeeRoleDataAccessModel
                    {
                        Id = e.Id,
                        Name = e.Name
                    }).ToListAsync().ConfigureAwait(false);
            };
        }

        public async Task Update(EmployeeRoleDataAccessModel model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.EmployeeRole
                    .Update(new EmployeeRole
                    {
                        Id = model.Id,
                        Name = model.Name
                    });

                await context.SaveChangesAsync().ConfigureAwait(false);
            };
        }

        public async Task Delete(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                EmployeeRole model = context.EmployeeRole.Where(e => e.Id == id).SingleOrDefault();

                if (model != null)
                {
                    context.EmployeeRole.Remove(model);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }

            };
        }
    }
}

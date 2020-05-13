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
    public class CustomerDataAccess : ICustomerDataAccess
    {
        public async Task Add(CustomerDataAccessModel model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.Customer.Add(new Customer
                {
                    Id = model.Id,
                    Name = model.Name,
                    Phone = model.Phone,
                    Active = model.Active,
                    Password = model.Password,
                    PasswordSalt = model.PasswordSalt,
                    Email = model.Email
                });

                await context.SaveChangesAsync().ConfigureAwait(false);
            };
        }

        public async Task Delete(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                Customer model = await context.Customer.Where(e => e.Id == id).SingleOrDefaultAsync();
                if (model != null)
                {
                    model.Active = false;
                    context.Customer.Update(model);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            };
        }

        public async Task<CustomerDataAccessModel> Get(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                Customer entity = await context.Customer.Where(e => e.Id == id).SingleOrDefaultAsync();

                if (entity != null)
                {
                    return new CustomerDataAccessModel
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Phone = entity.Phone,
                        Active = entity.Active,
                        Password = entity.Password,
                        PasswordSalt = entity.PasswordSalt,
                        Email = entity.Email
                    };
                }

                return null;
            };
        }

        public async Task<CustomerDataAccessModel> Get(string email)
        {
            using (var context = new PatinhasMimadasContext())
            {
                Customer entity = await context.Customer.Where(e => e.Email == email).SingleOrDefaultAsync();

                if (entity != null)
                {
                    return new CustomerDataAccessModel
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Phone = entity.Phone,
                        Active = entity.Active,
                        Password = entity.Password,
                        PasswordSalt = entity.PasswordSalt,
                        Email = entity.Email
                    };
                }

                return null;
            };
        }

        public async Task<List<CustomerDataAccessModel>> GetAll()
        {
            using (var context = new PatinhasMimadasContext())
            {
                List<Customer> entities = context.Customer.ToList();

                return await context.Customer
                    .Where(e => e.Active == true)
                    .Select(e => new CustomerDataAccessModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Phone = e.Phone,
                        Active = e.Active,
                        Email = e.Email
                    })
                    .ToListAsync();
            };
        }

        public async Task Update(CustomerDataAccessModel model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.Customer.Update(new Customer
                {
                    Id = model.Id,
                    Name = model.Name,
                    Phone = model.Phone,
                    Active = model.Active,
                    Email = model.Email,
                    Password = model.Password,
                    PasswordSalt = model.PasswordSalt,
                });

                await context.SaveChangesAsync().ConfigureAwait(false);
            };
        }
    }
}

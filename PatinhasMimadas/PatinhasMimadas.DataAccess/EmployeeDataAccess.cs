using Microsoft.EntityFrameworkCore;
using PatinhasMimadas.Data;
using PatinhasMimadas.DataAccess.Interfaces;
using PatinhasMimadas.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        public async Task<EmployeeDataAccessModel> Get(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                Employee entity = context.Employee.Where(e => e.Id == id).SingleOrDefault();

                if (entity != null)
                {
                    return new EmployeeDataAccessModel
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Phone = entity.Phone,
                        Birthdate = entity.Birthdate,
                        Salary = entity.Salary,
                        EmployeeRoleId = entity.EmployeeRoleId,
                        Active = entity.Active,
                        Password = entity.Password,
                        PasswordSalt = entity.PasswordSalt,
                        Email = entity.Email
                    };
                }

                return null;
            };
        }

        public async Task<EmployeeDataAccessModel> Get(string email)
        {
            using (var context = new PatinhasMimadasContext())
            {
                Employee entity = context.Employee.Where(e => e.Email == email).SingleOrDefault();

                if (entity != null)
                {
                    return new EmployeeDataAccessModel
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Phone = entity.Phone,
                        Birthdate = entity.Birthdate,
                        Salary = entity.Salary,
                        EmployeeRoleId = entity.EmployeeRoleId,
                        Active = entity.Active,
                        Password = entity.Password,
                        PasswordSalt = entity.PasswordSalt,
                        Email = entity.Email
                    };
                }

                return null;
            };
        }


        public async Task<List<EmployeeDataAccessModel>> GetAll()
        {
            using (var context = new PatinhasMimadasContext())
            {
                List<Employee> entities = context.Employee.ToList();

                return await context.Employee
                    .Where(e => e.Active == true)
                    .Select(e => new EmployeeDataAccessModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Phone = e.Phone,
                        Birthdate = e.Birthdate,
                        Salary = e.Salary,
                        EmployeeRoleId = e.EmployeeRoleId,
                        Active = e.Active,
                        Email = e.Email
                    })
                    .ToListAsync();
            };
        }

        public async Task<List<EmployeeDataAccessModel>> GetAllActives()
        {
            using (var context = new PatinhasMimadasContext())
            {
                List<Employee> entities = context.Employee.Where(e => e.Active == true).ToList();

                return await context.Employee
                    .Where(e => e.Active == true)
                    .Select(e => new EmployeeDataAccessModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Phone = e.Phone,
                        Birthdate = e.Birthdate,
                        Salary = e.Salary,
                        EmployeeRoleId = e.EmployeeRoleId,
                        Active = e.Active,
                        Email = e.Email
                    })
                    .ToListAsync();
            };
        }

        public async Task<List<EmployeeDataAccessModel>> GetAllInactives()
        {
            using (var context = new PatinhasMimadasContext())
            {
                List<Employee> entities = context.Employee.Where(e => e.Active == false).ToList();

                return await context.Employee
                    .Where(e => e.Active == true)
                    .Select(e => new EmployeeDataAccessModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Phone = e.Phone,
                        Birthdate = e.Birthdate,
                        Salary = e.Salary,
                        EmployeeRoleId = e.EmployeeRoleId,
                        Active = e.Active,
                        Email = e.Email
                    })
                    .ToListAsync();
            };
        }

        public async Task Add(EmployeeDataAccessModel model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.Employee.Add(new Employee
                {
                    Id = model.Id,
                    Name = model.Name,
                    Phone = model.Phone,
                    Birthdate = model.Birthdate,
                    Salary = (double)model.Salary,
                    EmployeeRoleId = model.EmployeeRoleId,
                    Active = model.Active,
                    Password = model.Password,
                    PasswordSalt = model.PasswordSalt,
                    Email = model.Email
                });

                await context.SaveChangesAsync().ConfigureAwait(false);
            };
        }

        public async Task Update(EmployeeDataAccessModel model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.Employee.Update(new Employee
                {
                    Id = model.Id,
                    Name = model.Name,
                    Phone = model.Phone,
                    Birthdate = model.Birthdate,
                    Salary = (double)model.Salary,
                    EmployeeRoleId = model.EmployeeRoleId,
                    Active = model.Active,
                    Email = model.Email,
                    Password = model.Password,
                    PasswordSalt = model.PasswordSalt,
                });

                await context.SaveChangesAsync().ConfigureAwait(false);
            };
        }

        public async Task Delete(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                Employee model = context.Employee.Where(e => e.Id == id).SingleOrDefault();
                if (model != null)
                {
                    model.Active = false;
                    context.Employee.Update(model);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            };
        }

    }
}

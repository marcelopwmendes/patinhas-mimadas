using PatinhasMimadas.Data;
using PatinhasMimadas.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess
{
    public class EmployeeRoleDataAccess : IEmployeeRoleDataAccess
    {
        public async Task Add(EmployeeRoleDataAccessModel entity)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.EmployeeRole.Add(new EmployeeRole { Id = entity.Id, Name = entity.Name });
                await context.SaveChangesAsync();
            };
        }

        public Task<EmployeeRoleDataAccessModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<EmployeeRoleDataAccessModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(EmployeeRoleDataAccessModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

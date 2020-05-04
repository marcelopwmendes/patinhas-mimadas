using PatinhasMimadas.Data;
using PatinhasMimadas.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess
{
    public interface IEmployeeRoleDataAccess
    {
        Task<EmployeeRoleDataAccessModel> Get(Guid id);

        Task<IList<EmployeeRoleDataAccessModel>> GetAll();

        Task Add(EmployeeRoleDataAccessModel entity);

        Task Update(EmployeeRoleDataAccessModel entity);
        
        Task Delete(Guid id);
    }
}

using PatinhasMimadas.Data;
using PatinhasMimadas.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess.Interfaces
{
    public interface IEmployeeRoleDataAccess
    {
        Task<EmployeeRoleDataAccessModel> Get(Guid id);

        Task<IList<EmployeeRoleDataAccessModel>> GetAll();

        Task Add(EmployeeRoleDataAccessModel model);

        Task Update(EmployeeRoleDataAccessModel model);
        
        Task Delete(Guid id);
    }
}

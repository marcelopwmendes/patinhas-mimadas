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
        Task<IList<EmployeeRoleDataAccessModel>> GetAll();

        Task<EmployeeRoleDataAccessModel> Get(Guid id);

        Task Add(EmployeeRoleDataAccessModel entity);

        Task Update(EmployeeRoleDataAccessModel entity);
    }
}

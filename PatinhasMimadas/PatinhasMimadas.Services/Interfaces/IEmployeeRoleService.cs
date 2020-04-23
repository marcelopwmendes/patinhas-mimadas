using PatinhasMimadas.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.Services.Interfaces
{
    public interface IEmployeeRoleService
    {
        Task<OperationResult<List<EmployeeRoleServiceModel>>> GetAsync();
        Task<OperationResult> AddAsync(EmployeeRoleServiceModel model);
    }
}

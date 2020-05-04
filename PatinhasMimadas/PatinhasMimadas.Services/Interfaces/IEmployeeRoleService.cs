using PatinhasMimadas.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.Services.Interfaces
{
    public interface IEmployeeRoleService
    {
        Task<OperationResult<EmployeeRoleServiceModel>> GetAsync(Guid id);
        Task<OperationResult<List<EmployeeRoleServiceModel>>> GetAllAsync();
        Task<OperationResult> AddAsync(EmployeeRoleServiceModel model);
        Task<OperationResult> UpdateAsync(EmployeeRoleServiceModel model);
        Task<OperationResult> DeleteAsync(Guid id);
    }
}

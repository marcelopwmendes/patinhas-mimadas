using PatinhasMimadas.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<OperationResult<EmployeeServiceModel>> GetAsync(Guid id);
        Task<OperationResult<List<EmployeeServiceModel>>> GetAllAsync();
        Task<OperationResult<List<EmployeeServiceModel>>> GetActivesAsync();
        Task<OperationResult<List<EmployeeServiceModel>>> GetInactivesAsync();
        Task<OperationResult> AddAsync(EmployeeServiceModel model);
        Task<OperationResult> UpdateAsync(EmployeeServiceModel model);
        Task<OperationResult> DeleteAsync(Guid id);
        Task<OperationResult> UpdateSalaryAsync(Guid id, double value);
        Task<OperationResult> VerifyCredentials(Guid id, string password);
        Task<OperationResult> ChangePassword(Guid id, string password);
        Task<OperationResult<EmployeeServiceModel>> VerifyEmail(string email);
    }
}

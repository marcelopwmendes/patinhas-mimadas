using PatinhasMimadas.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<OperationResult<CustomerServiceModel>> GetAsync(Guid id);
        Task<OperationResult<List<CustomerServiceModel>>> GetAllAsync();
        Task<OperationResult> AddAsync(CustomerServiceModel model);
        Task<OperationResult> UpdateAsync(CustomerServiceModel model);
        Task<OperationResult> DeleteAsync(Guid id);
        Task<OperationResult> VerifyCredentials(Guid id, string password);
        Task<OperationResult> ChangePassword(Guid id, string password);
        Task<OperationResult<CustomerServiceModel>> VerifyEmail(string email);
    }
}

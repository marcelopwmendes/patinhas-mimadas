using PatinhasMimadas.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.Services.Interfaces
{
    public interface IServiceService
    {
        Task<OperationResult<ServiceServiceModel>> GetAsync(Guid id);
        Task<OperationResult<List<ServiceServiceModel>>> GetAllAsync();
        Task<OperationResult> AddAsync(ServiceServiceModel model);
        Task<OperationResult> UpdateAsync(ServiceServiceModel model);
        Task<OperationResult> DeleteAsync(Guid id);
    }
}

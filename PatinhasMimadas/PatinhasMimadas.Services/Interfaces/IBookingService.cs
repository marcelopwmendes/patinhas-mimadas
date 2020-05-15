using PatinhasMimadas.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.Services.Interfaces
{
    public interface IBookingService
    {
        Task<OperationResult<BookingServiceModel>> GetAsync(Guid id);
        Task<OperationResult<List<BookingServiceModel>>> GetAllAsync();
        Task<OperationResult> AddAsync(BookingServiceModel model);
        Task<OperationResult> UpdateAsync(BookingServiceModel model);
        Task<OperationResult> DeleteAsync(Guid id);
    }
}

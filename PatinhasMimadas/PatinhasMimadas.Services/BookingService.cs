using PatinhasMimadas.DataAccess.Interfaces;
using PatinhasMimadas.DataAccess.Models;
using PatinhasMimadas.Services.Interfaces;
using PatinhasMimadas.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.Services
{
    public class BookingService : BaseService, IBookingService
    {
        private readonly IBookingDataAccess _dataAccess;

        public BookingService(IBookingDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<OperationResult<BookingServiceModel>> GetAsync(Guid id)
        {
            return await ExecuteOperationAsync(async () =>
            {
                BookingDataAccessModel dataAccessModel = await _dataAccess.Get(id);
                return new BookingServiceModel
                {
                    Id = dataAccessModel.Id,
                    ServiceId = dataAccessModel.ServiceId,
                    Confirmation = dataAccessModel.Confirmation,
                    CustomerId = dataAccessModel.CustomerId,
                    EmployeeId = dataAccessModel.EmployeeId,
                    Date = dataAccessModel.Date
                };
            });
        }

        public async Task<OperationResult<List<BookingServiceModel>>> GetAllAsync()
        {
            return await ExecuteOperationAsync(async () =>
            {
                IList<BookingDataAccessModel> dataAccessModels = await _dataAccess.GetAll();
                return dataAccessModels.Select(e => new BookingServiceModel
                {
                    Id = e.Id,
                    ServiceId = e.ServiceId,
                    Confirmation = e.Confirmation,
                    CustomerId = e.CustomerId,
                    EmployeeId = e.EmployeeId,
                    Date = e.Date
                }).ToList();
            });
        }

        public async Task<OperationResult> AddAsync(BookingServiceModel model)
        {
            return await ExecuteOperationAsync(async () =>
            {
                await _dataAccess.Add(new BookingDataAccessModel
                {
                    Id = Guid.NewGuid(),
                    ServiceId = model.ServiceId,
                    Confirmation = model.Confirmation,
                    CustomerId = model.CustomerId,
                    EmployeeId = model.EmployeeId,
                    Date = model.Date
                });
            });
        }

        public async Task<OperationResult> UpdateAsync(BookingServiceModel model)
        {
            return await ExecuteOperationAsync(async () =>
            {
                BookingDataAccessModel dataAccessModel = await _dataAccess.Get(model.Id);

                if (dataAccessModel.Confirmation != model.Confirmation)
                {
                    dataAccessModel.Confirmation = model.Confirmation;
                }
                if (dataAccessModel.Date != model.Date)
                {
                    dataAccessModel.Date = model.Date;
                }

                await _dataAccess.Update(dataAccessModel);
            });
        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            return await ExecuteOperationAsync(async () =>
            {
                await _dataAccess.Delete(id);
            });
        }
    }
}

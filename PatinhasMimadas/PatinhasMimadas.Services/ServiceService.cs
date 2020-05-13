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
    public class ServiceService : BaseService, IServiceService
    {

        private readonly IServiceDataAccess _dataAccess;

        public ServiceService(IServiceDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<OperationResult<ServiceServiceModel>> GetAsync(Guid id)
        {
            return await ExecuteOperationAsync(async () =>
            {
                ServiceDataAccessModel dataAccessModel = await _dataAccess.Get(id);
                return new ServiceServiceModel
                {
                    Id = dataAccessModel.Id,
                    Name = dataAccessModel.Name,
                    Price = dataAccessModel.Price
                };
            });
        }

        public async Task<OperationResult<List<ServiceServiceModel>>> GetAllAsync()
        {
            return await ExecuteOperationAsync(async () =>
            {
                IList<ServiceDataAccessModel> dataAccessModels = await _dataAccess.GetAll();
                return dataAccessModels.Select(e => new ServiceServiceModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price
                }).ToList();
            });
        }

        public async Task<OperationResult> AddAsync(ServiceServiceModel model)
        {
            return await ExecuteOperationAsync(async () =>
            {
                await _dataAccess.Add(new ServiceDataAccessModel
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Price = model.Price
                });
            });
        }

        public async Task<OperationResult> UpdateAsync(ServiceServiceModel model)
        {
            return await ExecuteOperationAsync(async () =>
            {
                ServiceDataAccessModel dataAccessModel = await _dataAccess.Get(model.Id);

                if (dataAccessModel.Name != model.Name)
                {
                    dataAccessModel.Name = model.Name;
                }
                if (dataAccessModel.Price != model.Price)
                {
                    dataAccessModel.Price = model.Price;
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

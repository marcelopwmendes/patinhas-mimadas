using PatinhasMimadas.DataAccess;
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
    public class EmployeeRoleService : BaseService, IEmployeeRoleService
    {

        private readonly IEmployeeRoleDataAccess _dataAccess;

        public EmployeeRoleService(IEmployeeRoleDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<OperationResult<EmployeeRoleServiceModel>> GetAsync(Guid id)
        {
            return await ExecuteOperationAsync(async () =>
            {
                EmployeeRoleDataAccessModel dataAccessModel = await _dataAccess.Get(id);
                return new EmployeeRoleServiceModel { Id = dataAccessModel.Id, Name = dataAccessModel.Name };
            });
        }

        public async Task<OperationResult<List<EmployeeRoleServiceModel>>> GetAllAsync()
        {
            return await ExecuteOperationAsync(async () =>
            {
                IList<EmployeeRoleDataAccessModel> dataAccessModels = await _dataAccess.GetAll();
                return dataAccessModels.Select(e => new EmployeeRoleServiceModel { Id = e.Id, Name = e.Name }).ToList();
            });
        }

        public async Task<OperationResult> AddAsync(EmployeeRoleServiceModel model)
        {
            return await ExecuteOperationAsync(async () =>
           {
               await _dataAccess.Add(new EmployeeRoleDataAccessModel
               {
                   Id = model.Id,
                   Name = model.Name
               });
           });
        }

        public async Task<OperationResult> UpdateAsync(EmployeeRoleServiceModel model)
        {
            return await ExecuteOperationAsync(async () =>
            {
                EmployeeRoleDataAccessModel dataAccessModel = await _dataAccess.Get(model.Id);

                if (dataAccessModel.Name != model.Name)
                {
                    dataAccessModel.Name = model.Name;
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

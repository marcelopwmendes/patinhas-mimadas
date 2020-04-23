using PatinhasMimadas.DataAccess;
using PatinhasMimadas.Services.Interfaces;
using PatinhasMimadas.Services.Models;
using System;
using System.Collections.Generic;
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

        public Task<OperationResult<List<EmployeeRoleServiceModel>>> GetAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<OperationResult> AddAsync(EmployeeRoleServiceModel model)
        {
            return await ExecuteOperationAsync(async () =>
           {
               await _dataAccess.Add(new DataAccess.Models.EmployeeRoleDataAccessModel
               {
                   Id = model.Id,
                   Name = model.Name
               });
           });
        }

    }
}

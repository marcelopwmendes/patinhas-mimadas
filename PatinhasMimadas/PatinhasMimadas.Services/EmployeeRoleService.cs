using PatinhasMimadas.Services.Interfaces;
using PatinhasMimadas.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.Services
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        public Task<OperationResult<List<EmployeeRoleServiceModel>>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}

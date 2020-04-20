using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatinhasMimadas.API.Models;
using PatinhasMimadas.Services;
using PatinhasMimadas.Services.Interfaces;
using PatinhasMimadas.Services.Models;

namespace PatinhasMimadas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : BaseController
    {
        private readonly IEmployeeRoleService _service;

        public EmployeeRoleController(IEmployeeRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ServiceCollectionResult<EmployeeRoleApiModel>> List()
        {
            OperationResult<List<EmployeeRoleServiceModel>> result = await _service.GetAsync();
            if (result.HasSucceeded)
            {
                return Success<EmployeeRoleApiModel>(result.Result.Select(m => new EmployeeRoleApiModel
                {
                    Id = m.Id,
                    Name = m.Name
                }
                ).ToList());
            }
            return Error<ServiceCollectionResult<EmployeeRoleApiModel>>(result.Error);
        }
    }
}
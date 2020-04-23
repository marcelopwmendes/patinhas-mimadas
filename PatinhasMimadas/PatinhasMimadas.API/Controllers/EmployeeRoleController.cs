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
    [Route("[controller]")]
    [ApiController]
    public class EmployeeRoleController : BaseController
    {
        private readonly IEmployeeRoleService _service;

        public EmployeeRoleController(IEmployeeRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Index()
        {
            return "Oi";
        }

        [Route("list")]
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

        [Route("add")]
        [HttpPost]
        public async Task<ServiceResult> Add(EmployeeRoleApiModel model)
        {
            OperationResult result = await _service.AddAsync(new EmployeeRoleServiceModel
            {
                Id = model.Id,
                Name = model.Name
            });

            if (result.HasSucceeded)
            {
                return Success(result);
            }
            else
            {
                return Error<ServiceResult>(result.Error);
            }
        }
    }
}
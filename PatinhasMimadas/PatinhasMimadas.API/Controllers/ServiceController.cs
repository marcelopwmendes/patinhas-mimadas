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
    public class ServiceController : BaseController
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<ServiceResult<ServiceApiModel>> Get([FromRoute]Guid id)
        {
            OperationResult<ServiceServiceModel> result = await _service.GetAsync(id);
            if (result.HasSucceeded)
            {
                return Success<ServiceApiModel>(new ServiceApiModel
                {
                    Id = result.Result.Id,
                    Name = result.Result.Name,
                    Price = result.Result.Price
                });
            }
            return Error<ServiceResult<ServiceApiModel>>(result.Error);
        }

        [Route("list")]
        [HttpGet]
        public async Task<ServiceCollectionResult<ServiceApiModel>> List()
        {
            OperationResult<List<ServiceServiceModel>> result = await _service.GetAllAsync();
            if (result.HasSucceeded)
            {
                return Success<ServiceApiModel>(result.Result.Select(m => new ServiceApiModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price
                }
                ).ToList());
            }
            return Error<ServiceCollectionResult<ServiceApiModel>>(result.Error);
        }

        [Route("add")]
        [HttpPost]
        public async Task<ServiceResult> Add(ServiceApiModel model)
        {
            OperationResult result = await _service.AddAsync(new ServiceServiceModel
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price
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

        [Route("update")]
        [HttpPut]
        public async Task<ServiceResult> Update(ServiceApiModel model)
        {
            OperationResult result = await _service.UpdateAsync(new ServiceServiceModel
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price
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

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<ServiceResult> Delete([FromRoute]Guid id)
        {
            OperationResult result = await _service.DeleteAsync(id);

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
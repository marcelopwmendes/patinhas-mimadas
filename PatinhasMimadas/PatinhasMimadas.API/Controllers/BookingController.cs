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
    public class BookingController : BaseController
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<ServiceResult<BookingApiModel>> Get([FromRoute]Guid id)
        {
            OperationResult<BookingServiceModel> result = await _service.GetAsync(id);
            if (result.HasSucceeded)
            {
                return Success<BookingApiModel>(new BookingApiModel
                {
                    Id = result.Result.Id,
                    ServiceId = result.Result.ServiceId,
                    Confirmation = result.Result.Confirmation,
                    CustomerId = result.Result.CustomerId,
                    EmployeeId = result.Result.EmployeeId,
                    Date = result.Result.Date
                });
            }
            return Error<ServiceResult<BookingApiModel>>(result.Error);
        }

        [Route("list")]
        [HttpGet]
        public async Task<ServiceCollectionResult<BookingApiModel>> List()
        {
            OperationResult<List<BookingServiceModel>> result = await _service.GetAllAsync();
            if (result.HasSucceeded)
            {
                return Success<BookingApiModel>(result.Result.Select(m => new BookingApiModel
                {
                    Id = m.Id,
                    ServiceId = m.ServiceId,
                    Confirmation = m.Confirmation,
                    CustomerId = m.CustomerId,
                    EmployeeId = m.EmployeeId,
                    Date = m.Date
                }
                ).ToList());
            }
            return Error<ServiceCollectionResult<BookingApiModel>>(result.Error);
        }

        [Route("add")]
        [HttpPost]
        public async Task<ServiceResult> Add(BookingApiModel model)
        {
            OperationResult result = await _service.AddAsync(new BookingServiceModel
            {
                Id = Guid.NewGuid(),
                ServiceId = model.ServiceId,
                Confirmation = model.Confirmation,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                Date = model.Date
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
        public async Task<ServiceResult> Update(BookingApiModel model)
        {
            OperationResult result = await _service.UpdateAsync(new BookingServiceModel
            {
                Id = model.Id,
                ServiceId = model.ServiceId,
                Confirmation = model.Confirmation,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                Date = model.Date
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatinhasMimadas.API.Models;
using PatinhasMimadas.Common.Enums;
using PatinhasMimadas.Services;
using PatinhasMimadas.Services.Interfaces;
using PatinhasMimadas.Services.Models;

namespace PatinhasMimadas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _service;
        private readonly IAccountService _accountService;

        public CustomerController(ICustomerService service, IAccountService accountService)
        {
            _service = service;
            _accountService = accountService;
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<ServiceResult<CustomerApiModel>> Get([FromRoute]Guid id)
        {
            OperationResult<CustomerServiceModel> result = await _service.GetAsync(id);
            if (result.HasSucceeded)
            {
                return Success<CustomerApiModel>(new CustomerApiModel
                {
                    Id = result.Result.Id,
                    Name = result.Result.Name,
                    Phone = result.Result.Phone,
                    Active = result.Result.Active,
                    Password = result.Result.Password,
                    Email = result.Result.Email
                });
            }

            return Error<ServiceResult<CustomerApiModel>>(result.Error);
        }

        [Route("list/all")]
        [HttpGet]
        public async Task<ServiceCollectionResult<CustomerApiModel>> ListAll()
        {
            OperationResult<List<CustomerServiceModel>> result = await _service.GetAllAsync();
            if (result.HasSucceeded)
            {
                return Success<CustomerApiModel>(result.Result.Select(m => new CustomerApiModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Phone = m.Phone,
                    Active = m.Active,
                    Password = m.Password,
                    Email = m.Email
                }
                ).ToList());
            }

            return Error<ServiceCollectionResult<CustomerApiModel>>(result.Error);
        }

        [Route("add")]
        [HttpPost]
        public async Task<ServiceResult> Add(CustomerApiModel model)
        {
            Guid salt = Guid.NewGuid();
            OperationResult result = await _service.AddAsync(new CustomerServiceModel
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Phone = model.Phone,
                Active = model.Active,
                Password = _accountService.EncriptPassword(model.Password, salt),
                PasswordSalt = salt,
                Email = model.Email
            });

            if (result.HasSucceeded)
            {
                return Success(result);
            }

            return Error<ServiceResult>(result.Error);
        }

        [Route("update")]
        [HttpPut]
        public async Task<ServiceResult> Update(CustomerApiModel model)
        {
            OperationResult result = await _service.UpdateAsync(new CustomerServiceModel
            {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Active = model.Active,
                Email = model.Email
            });

            if (result.HasSucceeded)
            {
                return Success(result);
            }

            return Error<ServiceResult>(result.Error);
        }

        [Route("delete/{id}")]
        [HttpPut]
        public async Task<ServiceResult> Delete([FromRoute]Guid id)
        {
            OperationResult result = await _service.DeleteAsync(id);

            if (result.HasSucceeded)
            {
                return Success(result);
            }

            return Error<ServiceResult>(result.Error);
        }

        [Route("{loggedId}/password/change/{id}")]
        [HttpPut]
        public async Task<ServiceResult> ChangePassword([FromRoute] Guid loggedId, [FromRoute] Guid id, ChangePasswordApiModel apiModel)
        {
            if (loggedId == id)
            {
                OperationResult<CustomerServiceModel> modelResult = await _service.GetAsync(loggedId);

                if (modelResult.HasSucceeded)
                {
                    string encryptedOldPassword = _accountService.EncriptPassword(apiModel.OldPassword, modelResult.Result.PasswordSalt);

                    OperationResult verification = await _service.VerifyCredentials(loggedId, encryptedOldPassword);

                    if (verification.HasSucceeded)
                    {
                        string encryptedNewPassword = _accountService.EncriptPassword(apiModel.NewPassword, modelResult.Result.PasswordSalt);
                        OperationResult result = await _service.ChangePassword(loggedId, encryptedNewPassword);

                        if (result.HasSucceeded)
                        {
                            return Success(result);
                        }

                        return Error<ServiceResult>(result.Error);
                    }
                }
            }

            return Error<ServiceResult>(ErrorEnum.Unauthorized);
        }

        [Route("password/reset/")]
        [HttpPut]
        public async Task<ServiceResult> ResetPassword(string email)
        {
            OperationResult<CustomerServiceModel> modelResult = await _service.VerifyEmail(email);

            if (modelResult.HasSucceeded)
            {
                string newPassword = _accountService.GeneratePassword();

                OperationResult<string> newPasswordResult = await _accountService.SendNewPassword(email, newPassword);

                if (newPasswordResult.HasSucceeded)
                {
                    string encryptedNewPassword = _accountService.EncriptPassword(newPasswordResult.Result, modelResult.Result.PasswordSalt);

                    OperationResult result = await _service.ChangePassword(modelResult.Result.Id, encryptedNewPassword);

                    if (result.HasSucceeded)
                    {
                        return Success(result);
                    }

                    return Error<ServiceResult>(result.Error);
                }

                return Error<ServiceResult>(newPasswordResult.Error);
            }

            return Error<ServiceResult>(modelResult.Error);
        }

    }
}
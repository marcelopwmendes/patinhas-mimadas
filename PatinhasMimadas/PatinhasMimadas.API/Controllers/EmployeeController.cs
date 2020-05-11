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
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _service;
        private readonly IAccountService _accountService;

        public EmployeeController(IEmployeeService service, IAccountService accountService)
        {
            _service = service;
            _accountService = accountService;
        }

        [Route("index")]
        [HttpGet]
        public async Task<ServiceResult<string>> Index()
        {
            OperationResult<string> newPasswordResult = await _accountService.SendNewPassword("xD");

            if (newPasswordResult.HasSucceeded)
            {
                return Success<string>(newPasswordResult.Result);
            }

            return Error<ServiceResult<string>>(newPasswordResult.Error);
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<ServiceResult<EmployeeApiModel>> Get([FromRoute]Guid id)
        {
            OperationResult<EmployeeServiceModel> result = await _service.GetAsync(id);
            if (result.HasSucceeded)
            {
                return Success<EmployeeApiModel>(new EmployeeApiModel
                {
                    Id = result.Result.Id,
                    Name = result.Result.Name,
                    Phone = result.Result.Phone,
                    Birthdate = result.Result.Birthdate,
                    Salary = result.Result.Salary,
                    EmployeeRoleId = result.Result.EmployeeRoleId,
                    Active = result.Result.Active,
                    Password = result.Result.Password,
                    Email = result.Result.Email
                });
            }

            return Error<ServiceResult<EmployeeApiModel>>(result.Error);
        }

        [Route("list/all")]
        [HttpGet]
        public async Task<ServiceCollectionResult<EmployeeApiModel>> ListAll()
        {
            OperationResult<List<EmployeeServiceModel>> result = await _service.GetAllAsync();
            if (result.HasSucceeded)
            {
                return Success<EmployeeApiModel>(result.Result.Select(m => new EmployeeApiModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Phone = m.Phone,
                    Birthdate = m.Birthdate,
                    Salary = m.Salary,
                    EmployeeRoleId = m.EmployeeRoleId,
                    Active = m.Active,
                    Password = m.Password,
                    Email = m.Email
                }
                ).ToList());
            }

            return Error<ServiceCollectionResult<EmployeeApiModel>>(result.Error);
        }

        [Route("list/actives")]
        [HttpGet]
        public async Task<ServiceCollectionResult<EmployeeApiModel>> ListActives()
        {
            OperationResult<List<EmployeeServiceModel>> result = await _service.GetActivesAsync();
            if (result.HasSucceeded)
            {
                return Success<EmployeeApiModel>(result.Result.Select(m => new EmployeeApiModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Phone = m.Phone,
                    Birthdate = m.Birthdate,
                    Salary = m.Salary,
                    EmployeeRoleId = m.EmployeeRoleId,
                    Active = m.Active,
                    Email = m.Email
                }
                ).ToList());
            }

            return Error<ServiceCollectionResult<EmployeeApiModel>>(result.Error);
        }

        [Route("list/inactives")]
        [HttpGet]
        public async Task<ServiceCollectionResult<EmployeeApiModel>> ListInactives()
        {
            OperationResult<List<EmployeeServiceModel>> result = await _service.GetInactivesAsync();
            if (result.HasSucceeded)
            {
                return Success<EmployeeApiModel>(result.Result.Select(m => new EmployeeApiModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Phone = m.Phone,
                    Birthdate = m.Birthdate,
                    Salary = m.Salary,
                    EmployeeRoleId = m.EmployeeRoleId,
                    Active = m.Active,
                    Email = m.Email
                }
                ).ToList());
            }

            return Error<ServiceCollectionResult<EmployeeApiModel>>(result.Error);
        }

        [Route("add")]
        [HttpPost]
        public async Task<ServiceResult> Add(EmployeeApiModel model)
        {
            Guid salt = Guid.NewGuid();
            OperationResult result = await _service.AddAsync(new EmployeeServiceModel
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Phone = model.Phone,
                Birthdate = model.Birthdate,
                Salary = model.Salary,
                EmployeeRoleId = model.EmployeeRoleId,
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
        public async Task<ServiceResult> Update(EmployeeApiModel model)
        {
            OperationResult result = await _service.UpdateAsync(new EmployeeServiceModel
            {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Birthdate = model.Birthdate,
                EmployeeRoleId = model.EmployeeRoleId,
                Active = model.Active,
                Email = model.Email,
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
                OperationResult<EmployeeServiceModel> modelResult = await _service.GetAsync(loggedId);

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
            OperationResult<EmployeeServiceModel> modelResult = await _service.VerifyEmail(email);

            if (modelResult.HasSucceeded)
            {
                OperationResult<string> newPasswordResult = await _accountService.SendNewPassword(email);

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

        [Route("{loggedId}/update/salary/{id}")]
        [HttpPut]
        public async Task<ServiceResult> SalaryUpdate([FromRoute] Guid loggedId, [FromRoute] Guid id, double newSalary)
        {
            //TODO Verify permissions of loggedId

            OperationResult result = await _service.UpdateSalaryAsync(id, newSalary);

            if (result.HasSucceeded)
            {
                return Success(result);
            }

            return Error<ServiceResult>(result.Error);
        }

    }
}
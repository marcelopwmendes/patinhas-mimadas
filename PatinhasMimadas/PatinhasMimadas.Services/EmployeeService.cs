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
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeDataAccess _dataAccess;

        public EmployeeService(IEmployeeDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<OperationResult<EmployeeServiceModel>> GetAsync(Guid id)
        {
            return await ExecuteOperationAsync(async () =>
            {
                EmployeeDataAccessModel dataAccessModel = await _dataAccess.Get(id);

                return new EmployeeServiceModel
                {
                    Id = dataAccessModel.Id,
                    Name = dataAccessModel.Name,
                    Phone = dataAccessModel.Phone,
                    Birthdate = dataAccessModel.Birthdate,
                    Salary = dataAccessModel.Salary,
                    EmployeeRoleId = dataAccessModel.EmployeeRoleId,
                    Active = dataAccessModel.Active,
                    Password = dataAccessModel.Password,
                    PasswordSalt = dataAccessModel.PasswordSalt,
                    Email = dataAccessModel.Email
                };

            });
        }

        public async Task<OperationResult<List<EmployeeServiceModel>>> GetAllAsync()
        {
            return await ExecuteOperationAsync(async () =>
            {
                List<EmployeeDataAccessModel> dataAccessModels = await _dataAccess.GetAll();
                return dataAccessModels.Select(e => new EmployeeServiceModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Phone = e.Phone,
                    Birthdate = e.Birthdate,
                    Salary = e.Salary,
                    EmployeeRoleId = e.EmployeeRoleId,
                    Active = e.Active,
                    Email = e.Email
                }).ToList();
            });
        }

        public async Task<OperationResult<List<EmployeeServiceModel>>> GetActivesAsync()
        {
            return await ExecuteOperationAsync(async () =>
            {
                List<EmployeeDataAccessModel> dataAccessModels = await _dataAccess.GetAllActives();
                return dataAccessModels.Select(e => new EmployeeServiceModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Phone = e.Phone,
                    Birthdate = e.Birthdate,
                    Salary = e.Salary,
                    EmployeeRoleId = e.EmployeeRoleId,
                    Active = e.Active,
                    Email = e.Email
                }).ToList();
            });
        }

        public async Task<OperationResult<List<EmployeeServiceModel>>> GetInactivesAsync()
        {
            return await ExecuteOperationAsync(async () =>
            {
                List<EmployeeDataAccessModel> dataAccessModels = await _dataAccess.GetAllInactives();
                return dataAccessModels.Select(e => new EmployeeServiceModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Phone = e.Phone,
                    Birthdate = e.Birthdate,
                    Salary = e.Salary,
                    EmployeeRoleId = e.EmployeeRoleId,
                    Active = e.Active,
                    Email = e.Email
                }).ToList();
            });
        }

        public async Task<OperationResult> AddAsync(EmployeeServiceModel model)
        {
            return await ExecuteOperationAsync(async () =>
            {
                await _dataAccess.Add(new EmployeeDataAccessModel
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Phone = model.Phone,
                    Birthdate = model.Birthdate,
                    Salary = (double)model.Salary,
                    EmployeeRoleId = model.EmployeeRoleId,
                    Active = model.Active,
                    Password = model.Password,
                    PasswordSalt = model.PasswordSalt,
                    Email = model.Email
                });
            });
        }

        public async Task<OperationResult> UpdateAsync(EmployeeServiceModel model)
        {
            return await ExecuteOperationAsync(async () =>
            {
                EmployeeDataAccessModel dataAccessModel = await _dataAccess.Get(model.Id);

                if (dataAccessModel.Name != model.Name)
                {
                    dataAccessModel.Name = model.Name;
                }

                if (dataAccessModel.Phone != model.Phone)
                {
                    dataAccessModel.Phone = model.Phone;
                }

                if (dataAccessModel.Birthdate != model.Birthdate)
                {
                    dataAccessModel.Birthdate = model.Birthdate;
                }

                if (dataAccessModel.EmployeeRoleId != model.EmployeeRoleId)
                {
                    dataAccessModel.EmployeeRoleId = model.EmployeeRoleId;
                }

                if (dataAccessModel.Active != model.Active)
                {
                    dataAccessModel.Active = model.Active;
                }

                if (dataAccessModel.Email != model.Email)
                {
                    dataAccessModel.Email = model.Email;
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

        public async Task<OperationResult> UpdateSalaryAsync(Guid id, double value)
        {
            return await ExecuteOperationAsync(async () =>
            {
                EmployeeDataAccessModel dataAccessModel = await _dataAccess.Get(id);
                dataAccessModel.Salary = value;

                await _dataAccess.Update(dataAccessModel);
            });

        }

        public async Task<OperationResult> VerifyCredentials(Guid id, string password)
        {
            return await ExecuteOperationAsync(async () =>
            {
                EmployeeDataAccessModel dataAccessModel = await _dataAccess.Get(id);

                if (dataAccessModel == null || dataAccessModel.Password != password)
                {
                    throw new Exception("User/Password incorrect");
                }
            });
        }

        public async Task<OperationResult> ChangePassword(Guid id, string password)
        {
            return await ExecuteOperationAsync(async () =>
            {
                EmployeeDataAccessModel dataAccessModel = await _dataAccess.Get(id);
                dataAccessModel.Password = password;

                await _dataAccess.Update(dataAccessModel);
            });
        }

        public async Task<OperationResult<EmployeeServiceModel>> VerifyEmail(string email)
        {
            return await ExecuteOperationAsync(async () =>
            {
                EmployeeDataAccessModel dataAccessModel = await _dataAccess.Get(email);

                return new EmployeeServiceModel
                {
                    Id = dataAccessModel.Id,
                    Name = dataAccessModel.Name,
                    Phone = dataAccessModel.Phone,
                    Birthdate = dataAccessModel.Birthdate,
                    Salary = dataAccessModel.Salary,
                    EmployeeRoleId = dataAccessModel.EmployeeRoleId,
                    Active = dataAccessModel.Active,
                    Password = dataAccessModel.Password,
                    PasswordSalt = dataAccessModel.PasswordSalt,
                    Email = dataAccessModel.Email
                };
            });
        }
    }
}

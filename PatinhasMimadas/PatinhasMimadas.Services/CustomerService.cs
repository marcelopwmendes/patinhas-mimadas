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
    public class CustomerService : BaseService, ICustomerService
    {

        private readonly ICustomerDataAccess _dataAccess;

        public CustomerService(ICustomerDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<OperationResult<CustomerServiceModel>> GetAsync(Guid id)
        {
            return await ExecuteOperationAsync(async () =>
            {
                CustomerDataAccessModel dataAccessModel = await _dataAccess.Get(id);

                return new CustomerServiceModel
                {
                    Id = dataAccessModel.Id,
                    Name = dataAccessModel.Name,
                    Phone = dataAccessModel.Phone,
                    Active = dataAccessModel.Active,
                    Password = dataAccessModel.Password,
                    PasswordSalt = dataAccessModel.PasswordSalt,
                    Email = dataAccessModel.Email
                };

            });
        }

        public async Task<OperationResult<List<CustomerServiceModel>>> GetAllAsync()
        {
            return await ExecuteOperationAsync(async () =>
            {
                List<CustomerDataAccessModel> dataAccessModels = await _dataAccess.GetAll();
                return dataAccessModels.Select(e => new CustomerServiceModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Phone = e.Phone,
                    Active = e.Active,
                    Email = e.Email
                }).ToList();
            });
        }

        public async Task<OperationResult> AddAsync(CustomerServiceModel model)
        {
            return await ExecuteOperationAsync(async () =>
            {
                await _dataAccess.Add(new CustomerDataAccessModel
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Phone = model.Phone,
                    Active = model.Active,
                    Password = model.Password,
                    PasswordSalt = model.PasswordSalt,
                    Email = model.Email
                });
            });
        }

        public async Task<OperationResult> UpdateAsync(CustomerServiceModel model)
        {
            return await ExecuteOperationAsync(async () =>
            {
                CustomerDataAccessModel dataAccessModel = await _dataAccess.Get(model.Id);

                if (dataAccessModel.Name != model.Name)
                {
                    dataAccessModel.Name = model.Name;
                }

                if (dataAccessModel.Phone != model.Phone)
                {
                    dataAccessModel.Phone = model.Phone;
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

        public async Task<OperationResult> ChangePassword(Guid id, string password)
        {
            return await ExecuteOperationAsync(async () =>
            {
                CustomerDataAccessModel dataAccessModel = await _dataAccess.Get(id);
                dataAccessModel.Password = password;

                await _dataAccess.Update(dataAccessModel);
            });
        }

        public async Task<OperationResult> VerifyCredentials(Guid id, string password)
        {
            return await ExecuteOperationAsync(async () =>
            {
                CustomerDataAccessModel dataAccessModel = await _dataAccess.Get(id);

                if (dataAccessModel == null || dataAccessModel.Password != password)
                {
                    throw new Exception("User/Password incorrect");
                }
            });
        }

        public async Task<OperationResult<CustomerServiceModel>> VerifyEmail(string email)
        {
            return await ExecuteOperationAsync(async () =>
            {
                CustomerDataAccessModel dataAccessModel = await _dataAccess.Get(email);

                return new CustomerServiceModel
                {
                    Id = dataAccessModel.Id,
                    Name = dataAccessModel.Name,
                    Phone = dataAccessModel.Phone,
                    Active = dataAccessModel.Active,
                    Password = dataAccessModel.Password,
                    PasswordSalt = dataAccessModel.PasswordSalt,
                    Email = dataAccessModel.Email
                };
            });
        }
    }
}

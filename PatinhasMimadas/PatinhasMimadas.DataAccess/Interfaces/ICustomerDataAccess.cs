using PatinhasMimadas.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess.Interfaces
{
    public interface ICustomerDataAccess
    {
        Task<CustomerDataAccessModel> Get(Guid id);
        Task<List<CustomerDataAccessModel>> GetAll();
        Task Add(CustomerDataAccessModel model);
        Task Update(CustomerDataAccessModel model);
        Task Delete(Guid id);
        Task<CustomerDataAccessModel> Get(string email);
    }
}

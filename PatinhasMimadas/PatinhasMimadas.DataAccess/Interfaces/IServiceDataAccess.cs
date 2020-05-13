using PatinhasMimadas.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess.Interfaces
{
    public interface IServiceDataAccess
    {
        Task<ServiceDataAccessModel> Get(Guid id);
        Task<IList<ServiceDataAccessModel>> GetAll();
        Task Add(ServiceDataAccessModel model);
        Task Delete(Guid id);
        Task Update(ServiceDataAccessModel model);
    }
}

using PatinhasMimadas.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess.Interfaces
{
    public interface IEmployeeDataAccess
    {
        public Task<EmployeeDataAccessModel> Get(Guid id);

        public Task<EmployeeDataAccessModel> Get(string email);

        public Task<List<EmployeeDataAccessModel>> GetAll();

        public Task<List<EmployeeDataAccessModel>> GetAllActives();

        public Task<List<EmployeeDataAccessModel>> GetAllInactives();

        public Task Add(EmployeeDataAccessModel model);

        public Task Update(EmployeeDataAccessModel model);

        public Task Delete(Guid id);
    }
}


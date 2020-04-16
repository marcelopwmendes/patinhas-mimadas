using PatinhasMimadas.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatinhasMimadas.DataAccess
{
    public class EmployeeDataAccess
    {
        public Employee Get(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                return context.Employee.Where(e => e.Id == id).SingleOrDefault();
            };
        }

        public List<Employee> GetAllActives()
        {
            using (var context = new PatinhasMimadasContext())
            {
                return context.Employee.Where(e => e.Active == true).ToList();
            };
        }

        public List<Employee> GetAllInactives()
        {
            using (var context = new PatinhasMimadasContext())
            {
                return context.Employee.Where(e => e.Active == true).ToList();
            };
        }

        public void Add(Employee model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.Employee.Add(model);
            };
        }

        public void Update(Employee model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.Employee.Update(model);
            };
        }

        public void Delete(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                Employee model = context.Employee.Where(e => e.Id == id).SingleOrDefault();
                if (model != null)
                {
                    model.Active = false;
                    context.Employee.Update(model);
                }
            };
        }
    }
}

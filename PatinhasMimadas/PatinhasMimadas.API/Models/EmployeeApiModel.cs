using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasMimadas.API.Models
{
    public class EmployeeApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long? Phone { get; set; }
        public DateTime? Birthdate { get; set; }
        public double? Salary { get; set; }
        public string Password { get; set; }
        public Guid EmployeeRoleId { get; set; }
        public bool? Active { get; set; }
        public string Email { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace PatinhasMimadas.Data.Models
{
    public partial class Employers
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long? Phone { get; set; }
        public DateTime? Birthdate { get; set; }
        public double Salary { get; set; }
        public string Password { get; set; }
        public Guid PasswordSalt { get; set; }
        public Guid EmployeeRoleId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatinhasMimadas.Data
{
    [Table("Employers")]

    public partial class Employee
    {
        public Employee()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public long? Phone { get; set; }
        public DateTime? Birthdate { get; set; }
        public double Salary { get; set; }
        public string Password { get; set; }
        public Guid PasswordSalt { get; set; }
        public Guid EmployeeRoleId { get; set; }
        public bool? Active { get; set; }
        public string Email { get; set; }

        public virtual EmployeeRole EmployeeRole { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatinhasMimadas.Data
{
    [Table("EmployeeRoles")]
    public partial class EmployeeRole
    {
        public EmployeeRole()
        {
            Employers = new HashSet<Employee>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employers { get; set; }
    }
}

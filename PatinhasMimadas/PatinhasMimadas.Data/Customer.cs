﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatinhasMimadas.Data
{
    [Table("Customers")]
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public string Password { get; set; }
        public Guid PasswordSalt { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}

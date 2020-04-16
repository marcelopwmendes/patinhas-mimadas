using System;
using System.Collections.Generic;

namespace PatinhasMimadas.Data.Models
{
    public partial class Customers
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public string Password { get; set; }
        public Guid PasswordSalt { get; set; }
    }
}

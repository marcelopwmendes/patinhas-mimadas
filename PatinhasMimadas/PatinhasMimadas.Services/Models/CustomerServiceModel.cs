using System;
using System.Collections.Generic;
using System.Text;

namespace PatinhasMimadas.Services.Models
{
    public class CustomerServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public string Password { get; set; }
        public Guid PasswordSalt { get; set; }
        public bool? Active { get; set; }
    }
}

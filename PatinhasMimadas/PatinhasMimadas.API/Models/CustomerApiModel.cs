using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasMimadas.API.Models
{
    public class CustomerApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }
    }
}

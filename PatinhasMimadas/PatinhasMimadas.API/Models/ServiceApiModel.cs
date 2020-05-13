using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasMimadas.API.Models
{
    public class ServiceApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}

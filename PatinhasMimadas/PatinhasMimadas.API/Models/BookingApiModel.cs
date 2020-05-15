using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasMimadas.API.Models
{
    public class BookingApiModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public bool? Confirmation { get; set; }
        public Guid ServiceId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}

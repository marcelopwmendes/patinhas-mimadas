using System;
using System.Collections.Generic;
using System.Text;

namespace PatinhasMimadas.Services.Models
{
    public class BookingServiceModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public bool? Confirmation { get; set; }
        public Guid ServiceId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}

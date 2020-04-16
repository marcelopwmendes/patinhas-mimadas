using System;
using System.Collections.Generic;

namespace PatinhasMimadas.Data.Models
{
    public partial class Bookings
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public bool? Confirmation { get; set; }
        public Guid ServiceId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}

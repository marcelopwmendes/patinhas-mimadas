using System;
using System.Collections.Generic;

namespace PatinhasMimadas.Data
{
    public partial class Booking
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public bool? Confirmation { get; set; }
        public Guid ServiceId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? EmployeeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Service Service { get; set; }
    }
}

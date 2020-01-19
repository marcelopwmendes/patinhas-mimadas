namespace PatinhasMimadas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public Guid Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public bool Confirmation { get; set; }

        public Guid ServiceId { get; set; }

        public Guid CustomerId { get; set; }

        public Guid? EmployeeId { get; set; }

        public virtual Customer Customers { get; set; }

        public virtual Employee Employees { get; set; }

        public virtual Service Services { get; set; }
    }
}

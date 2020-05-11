using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatinhasMimadas.Data
{
    [Table("Services")]
    public partial class Service
    {
        public Service()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace PatinhasMimadas.Data
{
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

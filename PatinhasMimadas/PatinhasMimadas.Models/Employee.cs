namespace PatinhasMimadas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public long Phone { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Birthdate { get; set; }

        public int Salary { get; set; }

        [Required]
        [MaxLength(50)]
        public byte[] Password { get; set; }

        public Guid EmployeeRoleId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual EmployeeRole EmployeeRoles { get; set; }
    }
}

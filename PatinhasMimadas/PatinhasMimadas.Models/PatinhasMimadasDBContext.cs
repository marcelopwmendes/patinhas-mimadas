namespace PatinhasMimadas.Models {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PatinhasMimadasDBContext : DbContext {
        public PatinhasMimadasDBContext()
            : base("name=PatinhasMimadas") {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRole { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Customers)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeRole>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeRole>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.EmployeeRoles)
                .HasForeignKey(e => e.EmployeeRoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Bookings)
                .WithOptional(e => e.Employees)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<Services>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Services>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Services)
                .HasForeignKey(e => e.ServiceId)
                .WillCascadeOnDelete(false);
        }
    }
}

namespace LoginSignup.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TripContext : DbContext,ITripContext
    {
        public TripContext()
            : base("name=TripContext")
        {
        }

        public virtual DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>()
                .Property(e => e.source)
                .IsUnicode(false);

            modelBuilder.Entity<Trip>()
                .Property(e => e.destination)
                .IsUnicode(false);

            modelBuilder.Entity<Trip>()
                .Property(e => e.estimated_cost)
                .HasPrecision(8, 2);
        }
    }
}

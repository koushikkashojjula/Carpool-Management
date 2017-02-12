namespace CMSTest.TripClasses
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TestTripContext : DbContext
    {
        public TestTripContext()
            : base("name=TestTripContext")
        {
        }

        public virtual DbSet<Test_Trips> Test_Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test_Trips>()
                .Property(e => e.source)
                .IsUnicode(false);

            modelBuilder.Entity<Test_Trips>()
                .Property(e => e.destination)
                .IsUnicode(false);

            modelBuilder.Entity<Test_Trips>()
                .Property(e => e.estimated_cost)
                .HasPrecision(8, 2);
        }
    }
}

namespace CMSTest.TripClasses
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBTestContext : DbContext
    {
        public DBTestContext()
            : base("name=DBTestContext")
        {
        }

        public virtual DbSet<DBTest> DBTests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBTest>()
                .Property(e => e.source)
                .IsUnicode(false);

            modelBuilder.Entity<DBTest>()
                .Property(e => e.destination)
                .IsUnicode(false);

            modelBuilder.Entity<DBTest>()
                .Property(e => e.estimated_cost)
                .HasPrecision(8, 2);
        }
    }
}

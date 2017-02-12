namespace CMSTest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TestUserContext : DbContext
    {
        public TestUserContext()
            : base("name=TestUserContext")
        {
        }

        public virtual DbSet<Test_Users> Test_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

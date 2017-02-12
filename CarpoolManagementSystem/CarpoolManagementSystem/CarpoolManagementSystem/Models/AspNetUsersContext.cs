namespace LoginSignup.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AspNetUsersContext : DbContext
    {
        public AspNetUsersContext()
            : base("name=AspNetUsersContext")
        {
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

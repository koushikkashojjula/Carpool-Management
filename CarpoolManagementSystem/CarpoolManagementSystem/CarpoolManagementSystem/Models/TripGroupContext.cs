using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LoginSignup.Models
{
    public class TripGroupContext:DbContext
    {
        public TripGroupContext()
            : base("name=TripGroupContext")
        {
        }
        public DbSet<TripGroup> TripGroups { get; set; }
    }
}
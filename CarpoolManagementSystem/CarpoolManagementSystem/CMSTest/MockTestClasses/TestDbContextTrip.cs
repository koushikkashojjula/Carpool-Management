using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginSignup.Models;
using System.Data.Entity;
using System.Collections.ObjectModel;


namespace CMSTest.TripClasses
{
    
        class TestDbContextTrip : ITripContext
        {
            public DbSet<Trip> Trips { get; set; }
            public TestDbContextTrip(TestTripDbset x)
            {
                this.Trips = x;
            }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LoginSignup.Models
{
    public interface ITripContext
    {
        DbSet<Trip> Trips { get; }
    }
}
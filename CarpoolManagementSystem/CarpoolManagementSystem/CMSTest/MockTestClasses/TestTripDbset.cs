using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginSignup.Models;

namespace CMSTest.TripClasses
{
   
        class TestTripDbset : TestDbsetTrip<Trip>
        {
            public override Trip Find(params object[] keyValues)
            {
                //return base.Find(keyValues);
                return this.FirstOrDefault(t => t.id == (int)keyValues.Single());

            }
        
    }
}

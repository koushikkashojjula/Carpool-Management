using CMSTest.TripClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSTest.DataDependencyTest
{
    
    [TestClass]
    public class Insertion_Retrieval_TestTrips
    {
        [TestMethod]
        public void Insertion_Test_Trips()
        {
            TestTripContext dbcontext = new TestTripContext();
            Test_Trips trip = new Test_Trips
            {
                source="Source1",
                destination="Destination1",
                date="12/13/2016"
            };
            dbcontext.Test_Trips.Add(trip);
            dbcontext.SaveChanges();
            List<Test_Trips> list_trips = new List<Test_Trips>();
            list_trips = dbcontext.Test_Trips.Where(a => a.source == "Source1" && a.destination=="Destination1").ToList();
            Assert.AreEqual("12/13/2016", list_trips[list_trips.Count - 1].date);
        }
    }
}

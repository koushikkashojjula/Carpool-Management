using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using LoginSignup.Models;
using System.Web.Mvc;
using CMSTest.TripClasses;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using Moq;
using System.Diagnostics;

namespace CMSTest
{
    [TestClass]
    public class TripControllerTest
    {
        public object HttpContext { get; private set; }


        TestTripDbset trips = new TestTripDbset();
        Trip trip1 = new Trip
        {
            id = 1,
            source = "durham",
            destination = "hyderabad",
            created_by = "bhanu",
            carAvailable = true,
            vacant_seats = 4,
            estimated_cost = 25,
            description = null
        };
        Trip trip2 = new Trip
        {
            id = 2,
            source = "charlotte",
            destination = "chapel hill",
            created_by = "koushik",
            carAvailable = true,
            vacant_seats = 3,
            estimated_cost = 30,
            description = "xyz"
        };

        [TestMethod]
        public void TripDetailsTest()
        {
            
            trips.Add(trip1);
            trips.Add(trip2);

            TestDbContextTrip t_c_t = new TestDbContextTrip(trips);
            t_c_t.Trips.Add(trip1);
            t_c_t.Trips.Add(trip2);
            var controller = new TripController(t_c_t);
            var result = controller.TripDetails(1) as ViewResult;
            var model = controller.ViewData.Model;
            Assert.AreEqual(trip1, model);
        }

        [TestMethod]
        public void ShowTripDataTest()
        {
            trips.Add(trip1);
            trips.Add(trip2);

            TestDbContextTrip t_c_t = new TestDbContextTrip(trips);
            t_c_t.Trips.Add(trip1);
            t_c_t.Trips.Add(trip2);

            SearchBarModel searchBarModel = new SearchBarModel
            {
                source = "charlotte",
            };

            var tripController = new TripController(t_c_t);
            var result = tripController.ShowTripData(searchBarModel) as ViewResult;
            List<Trip> model = (List < Trip >) tripController.ViewData.Model;
            Assert.AreEqual(trip2, model[0]);
        }

        

        [TestMethod]
        public void TripdetailsReturnTest()
        {
            TestTripDbset a = new TestTripDbset();
            Trip a1 = new Trip
            {
                id = 1,
                source = "durham",
                destination = "hyderabad",
                created_by = "bhanu",
                carAvailable = true,
                vacant_seats = 4,
                estimated_cost = 25,
                description = null
            };
            a.Add(a1);
            TestDbContextTrip t_c_t = new TestDbContextTrip(a);
            t_c_t.Trips.Add(a1);
            var controller = new TripController(t_c_t);
            var result = controller.TripDetails(1) as ViewResult;
            Assert.AreEqual("TripDetails", result.ViewName);
        }

        [TestMethod]
        public void ShowJoinButtonTest()
        {
            TestTripDbset a = new TestTripDbset();
            Trip a1 = new Trip
            {
                id = 1,
                source = "durham",
                destination = "hyderabad",
                created_by = "bhanu",
                carAvailable = true,
                vacant_seats = 4,
                estimated_cost = 25,
                description = null
            };
            a.Add(a1);
            TestDbContextTrip t_c_t = new TestDbContextTrip(a);
            t_c_t.Trips.Add(a1);
            var controller = new TripController(t_c_t);
            var result =controller.ShowJoinButton("1");
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public void SMTPEmailTest()
        {
            TripController tripController = new TripController();
            bool x = tripController.SMTPSendEmail("carpoolmanagementsystem@gmail.com", 
                "Testing Email", 
                "This email has been sent by automated unit test");
            Assert.IsTrue(x);
        }

        [TestMethod]
        public void JoinTripTest()
        {
            var fakeHttpContext = new Mock<System.Web.HttpContextBase>();
            var fakeIdentity = new GenericIdentity("carpoolmanagementsystem@gmail.com");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);
            var tripcontroller = new TripController();
            tripcontroller.ControllerContext = controllerContext.Object;

            var result=tripcontroller.JoinTrip("89");
            bool x=false;
            if (result == "2" || result == "3")
            {
                x = true;
            }
            Assert.AreEqual(true,x);
        }
        [TestMethod]
        public void Test_AddTripToModel()
        {
            trips.Add(trip1);
            trips.Add(trip2);
            TestDbContextTrip t_c_t = new TestDbContextTrip(trips);

            Trip t = new Trip
            {
                id = 4,
                source = "charlotte",
                destination = "DC",
                created_by = "Bhanu",
                carAvailable = true,
                vacant_seats = 2,
                estimated_cost = 45,
                description = "xyz"
            };
            t_c_t.Trips.Add(t);
            Assert.AreEqual(t, t_c_t.Trips.Find(4));
        }
        [TestMethod]
        public void Test_RemoveTripFromModel()
        {
            trips.Add(trip1);
            trips.Add(trip2);
            TestDbContextTrip t_c_t = new TestDbContextTrip(trips);
            t_c_t.Trips.Remove(trip1);
            Assert.AreEqual(null, t_c_t.Trips.Find(1));
        }

        //[TestMethod]
        //public void ShowTripReturnTest()
        //{
        //    var controller = new TripController();
        //    var searchbarmodel = new SearchBarModel()
        //    {
        //        source = "charlotte",
        //        destination = "new york",
        //        date = "01/01/2026"
        //    };
        //    var result = controller.ShowTripData(searchbarmodel) as ViewResult;
        //    Assert.AreEqual("ShowTripData", result.ViewName);
        //}
    }
}

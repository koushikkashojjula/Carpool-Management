using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using LoginSignup.Models;
using System.Web.Mvc;

namespace CMSTest
{
    public class UnitTest2
    {
        [TestMethod]
        public void ShowTripReturnTest()
        {
            var controller = new TripController();
            //var searchbarmodel = new SearchBarModel()
            //{ source = "charlotte", destination = "new york", date = "01/01/2026" };
            //searchbarmodel.source = "charlotte";
            //searchbarmodel.destination = "new york";
            //searchbarmodel.date = "01/01/2017";
            var result = controller.ShowTripData(new SearchBarModel() { source = "charlotte", destination = "new york", date = "01/01/2026" }) as ViewResult;
            Assert.AreEqual("ShowTripData", result.ViewName);
        }
    }
}

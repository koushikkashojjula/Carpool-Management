using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using System.Web.Mvc;
using LoginSignup.Models;

namespace CMSTest
{
    [TestClass]
    public class Addtriptest
    {
        [TestMethod]
        public void Addtripreturntest()
        {
            
            var controller = new HomeController();
            var result = controller.AddTrip() as ViewResult;
            Assert.AreEqual("AddTrip", result.ViewName);
        }
    }
}

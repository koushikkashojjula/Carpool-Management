using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using LoginSignup.Models;
using System.Web.Mvc;
using Moq;

namespace LoginSignup.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexReturnTest()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void AboutViewbagTest()
        {
            var controller = new HomeController();
            var result = controller.About() as ViewResult;
            Assert.AreEqual("Your application description page.", result.ViewData["Message"]);
        }
        [TestMethod]
        public void ContactViewbagTest()
        {
            var controller = new HomeController();
            var result = controller.Contact() as ViewResult;
            Assert.AreEqual("Your contact page.", result.ViewData["Message"]);
        }
        [TestMethod]
        public void TripDetailsReturnTest()
        {
            var controller = new HomeController();
            var result = controller.TripDetails() as ViewResult;
            Assert.AreEqual("TripDetails", result.ViewName);
        }
        //[TestMethod]
        //public void AddTripReturnTest()
        //{
        //    var controller = new HomeController();
        //    var result = controller.AddTrip() as ViewResult;
        //    Assert.AreEqual("AddTrip", result.ViewName);
        //}
        [TestMethod]
        public void AboutReturnTest()
        {
            var controller = new HomeController();
            var result = controller.About() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }
        [TestMethod]
        public void ContactReturnTest()
        {
            var controller = new HomeController();
            var result = controller.Contact() as ViewResult;
            Assert.AreEqual("Contact", result.ViewName);
        }
        //[TestMethod]
        //public void ShowTripReturnTest()
        //{
        //    var controller = new TripController();
        //    var searchbarmodel = new SearchBarModel()
        //    { source = "charlotte", destination = "new york", date = "01/01/2026" };
        //    //searchbarmodel.source = "charlotte";
        //    //searchbarmodel.destination = "new york";
        //    //searchbarmodel.date = "01/01/2017";
        //    var result = controller.ShowTripData(searchbarmodel) as ViewResult;
        //    Assert.AreEqual("ShowTripData", result.ViewName);
        //}
        //[TestMethod]
        //public void RegisterReturnTest()
        //{
        //    var controller = new AccountController();
        //    var result = controller.Register() as ViewResult;
        //    Assert.AreEqual("Register", result.ViewName);
        //}
        //[TestMethod]
        //public void successRegisterReturnTest()
        //{
        //    var controller = new AccountController();
        //    RegisterViewModel model = new RegisterViewModel { Email = "bhanu@gmail.com", Password = "bhanu1995", ConfirmPassword = "bhanu1995" };
        //    var result = controller.Register(model).Result;
        //    Assert.IsTrue(result is ViewResult);
        //    ////var result = controller.Register() as ViewResult;
        //    ////Assert.AreEqual("Register", result.ViewName);
        //}
    }
}


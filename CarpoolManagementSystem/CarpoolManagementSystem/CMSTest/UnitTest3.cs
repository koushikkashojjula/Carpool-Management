using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using LoginSignup.Models;
using System.Web.Mvc;

namespace CMSTest
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void RegisterReturnTest()
        {
            var controller = new AccountController();
            var result = controller.Register() as ViewResult;
            Assert.AreEqual("Register", result.ViewName);
        }
        //[TestMethod]
        //public void PostRegisterReturnTest()
        //{
        //    var controller = new AccountController();
        //    var m = new RegisterViewModel() { Email = "bhanu@gmail.com", Password = "bhanu1995", ConfirmPassword = "bhanu1995" };
            
        //}
    }
}

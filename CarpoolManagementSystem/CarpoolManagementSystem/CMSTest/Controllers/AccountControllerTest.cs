using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using System.Web.Mvc;

namespace CMSTest
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void RegisterReturnTest()
        {
            var controller = new AccountController();
            var result = controller.Register() as ViewResult;
            Assert.AreEqual("Register", result.ViewName);
        }
        [TestMethod]
        public void LoginReturnTest()
        {
            var controller = new AccountController();
            var result = controller.Login(null) as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
        }

        [TestMethod]
        public void ExternalLoginFailTest()
        {
            var controller = new AccountController();
            var result = controller.ExternalLoginFailure() as ViewResult;
            Assert.AreEqual("Login Failed", result.ViewName);
        }
    }   
}

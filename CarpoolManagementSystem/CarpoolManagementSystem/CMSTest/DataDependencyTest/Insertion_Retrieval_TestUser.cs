using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CMSTest.DataDependencyTest
{
    /// <summary>
    /// Summary description for Insertion_Retrieval_TestUser
    /// </summary>
    [TestClass]
    public class Insertion_Retrieval_TestUser
    {
        [TestMethod]
        public void Insertion_Test_User()
        {
            TestUserContext dbcontext = new TestUserContext();
            Test_Users user = new Test_Users
            {
                Email = "test@gmail.com",
                UserName = "test"
            };
            dbcontext.Test_Users.Add(user);
            dbcontext.SaveChanges();
            List<Test_Users> list_users = new List<Test_Users>();
            list_users = dbcontext.Test_Users.Where(a => a.UserName == "test").ToList();
            Assert.AreEqual("test@gmail.com", list_users[list_users.Count-1].Email);
        }
    }
}

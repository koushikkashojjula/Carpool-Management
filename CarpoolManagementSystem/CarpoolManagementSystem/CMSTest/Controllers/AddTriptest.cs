using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginSignup.Controllers;
using System.Web.Mvc;
using LoginSignup.Models;
using System.Collections;

namespace CMSTest.Controllers
{
    class AddTriptest
    {
        public void tripviewtest()
        {

            var controller = new HomeController();
            bool x = controller.User.Identity.IsAuthenticated;
        }
    }
}

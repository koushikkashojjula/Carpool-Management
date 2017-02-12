using LoginSignup.Models;
using System.Web.Mvc;

namespace LoginSignup.Controllers
{
    public class DbController : Controller
    {
        public CodeDB DB = new CodeDB();

        // GET: Db
        public ActionResult Index()
        {
            bool bStatus = DB.Open();
            if (bStatus)
            {
                return Content(bStatus.ToString());
            }
            else
            {
                return Content(bStatus.ToString());
            }
        }
    }
}
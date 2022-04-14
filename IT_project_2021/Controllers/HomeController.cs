using IT_project_2021.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_project_2021.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = System.Web.HttpContext
                    .Current
                    .GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindByEmail(User.Identity.Name);

                //ViewBag.FullName = String.Format("{0} {1}",
                //    user.FirstName,
                //    user.LastName
                //);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
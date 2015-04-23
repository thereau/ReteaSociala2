using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReteaSocialaMDS.Models;

namespace ReteaSocialaMDS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Search(string userName)
        {
            return View();
        }

        public ActionResult NewPost()
        {
            var model = new PostViewModel();
            return PartialView("_NewPost",model);
        }
    }
}
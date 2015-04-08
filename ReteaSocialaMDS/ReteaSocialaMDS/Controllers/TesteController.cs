using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReteaSocialaMDS.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult Index(String mesaj, int varsta=0)
        {
            ViewBag.MessagePrimit = mesaj;
            ViewBag.Message = "Gigel este pe camp";
            ViewBag.Varsta = varsta;
            return View();
        }

        public ActionResult lista()
        {
            return PartialView();
        }
        
    }
}
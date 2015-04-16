using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReteaSocialaMDS.Models.Teste;

namespace ReteaSocialaMDS.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public ViewResult Index(String mesaj, int varsta=0)
        {
            ViewBag.MessagePrimit = mesaj;
            ViewBag.Message = "Gigel este pe camp";
            ViewBag.Varsta = varsta;
            return View();
        }

        public PartialViewResult lista()
        {
            return PartialView();
        }

        [HttpGet]
        public ViewResult testeRequestParams()
        {
            //In ASP.NET, the Request.Params dictionary results from the combination of four distinct dictionaries: QueryString, Form, Cookies, and ServerVariables.
            var nume = Request.Params["nume"] ?? "nu a fost transmis un nume";
            ViewBag.nume = nume;

            //var Gigel = new TesteIndexMVVM {Nume = "Gigel", Prenume = "Ionel", Varsta = 120};
            var model = new TesteIndexMVVM();
         
            return View(model);
        }

        [HttpPost]
        public ViewResult testeRequestParams(TesteIndexMVVM data)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Datele nu sunt valide pentru acest model");
            }
            return View();
        }
    }
}
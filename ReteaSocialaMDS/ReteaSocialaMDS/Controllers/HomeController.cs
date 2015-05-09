using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ReteaSocialaMDS.Models;

namespace ReteaSocialaMDS.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
            return PartialView("_NewPost", model);
        }

        [Authorize]
        public ActionResult CreateUserImage()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUserImage(ImageViewModel imageModel)
        {
            if (imageModel.ImageUpload == null)
            {
                ModelState.AddModelError("ImageUpload", "You have to upload an image");
            }
            else if (imageModel.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "You have to select a valid image");
            }
            if (imageModel.ImageUpload != null)
            {
                switch (imageModel.ImageUpload.ContentType)
                {
                    case "image/png":
                    case "image/jpeg":
                    case "image/pjpeg":
                    case "image/gif":
                        break;
                    default:
                        {
                            ModelState.AddModelError("ImageUpload", "Your file is not a valid MYME type");
                            break;
                        }

                }
            }


            if (ModelState.IsValid)
            {
                var uploadDir = "~/Images/Users/";

                var imageName = User.Identity.GetUserId() + imageModel.ImageUpload.FileName;
                var imagePath = Path.Combine(Server.MapPath(uploadDir), imageName);
                imageModel.ImageUpload.SaveAs(imagePath);
                var imageUrl = Path.Combine(uploadDir, imageName);

                var newImage = new UserImage()
                {
         
                    OwnerId = User.Identity.GetUserId(),
                    Title = imageModel.Title,
                    Description = imageModel.Description,
                    ImageUrl = imageUrl

                };



                db.UserImage.Add(newImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imageModel);
        }
        [Authorize]
        [HttpGet]
        public ActionResult UserImagesList()
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            ApplicationUser user = userManager.FindById(User.Identity.GetUserId());

            IEnumerable<string> imgs = (from image in user.UserImages select Url.Content(image.ImageUrl)).Take(5).ToList();

            return View(imgs);
            
        }

        [Authorize]
        [HttpPost]
        public JsonResult UserImagesList(int skip)
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            ApplicationUser user = userManager.FindById(User.Identity.GetUserId());

            IEnumerable<string> imgs = (from image in user.UserImages select Url.Content(image.ImageUrl)).Skip(skip).Take(5).ToList();
            
            return Json(imgs);

        }
    }
}
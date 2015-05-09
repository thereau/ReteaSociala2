using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ReteaSocialaMDS.Models;

namespace ReteaSocialaMDS.Controllers
{
    public class ImageModelsController : Controller
    {
        private ReteaSocialaMDSContext db = new ReteaSocialaMDSContext();

        // GET: ImageModels
        public ActionResult Index()
        {
            IEnumerable<ImageModel> imageModels = db.ImageModels.ToList();
            IEnumerable<ImageDetailsViewModel> imageDetailsViewModels =(from img in imageModels select new ImageDetailsViewModel
            {
                Title = img.Title,
                Description = img.Description,
                ImageUrl = img.ImageUrl

            }).ToList();

            return View(imageDetailsViewModels);
        }

        // GET: ImageModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageModel imageModel = db.ImageModels.Find(id);
            if (imageModel == null)
            {
                return HttpNotFound();
            }
            return View(imageModel);
        }

        // GET: ImageModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageViewModel imageModel)
        {
            if (imageModel.ImageUpload == null)
            {
                ModelState.AddModelError("ImageUpload","You have to upload an image");
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
                        ModelState.AddModelError("ImageUpload","Your file is not a valid MYME type");
                        break;
                    }

                }
            }
            

            if (ModelState.IsValid)
            {
                var uploadDir = "~/Images/Users/";
                var imageName =  User.Identity.GetUserId() + imageModel.ImageUpload.FileName;
                var imagePath = Path.Combine(Server.MapPath(uploadDir), imageName);
                imageModel.ImageUpload.SaveAs(imagePath);
                var imageUrl = Path.Combine(uploadDir, imageName);
                
                var newImage = new ImageModel
                {
                    //UserId = int.Parse(User.Identity.GetUserId()),
                    UserId = 1,
                    Title=imageModel.Title,
                    Description = imageModel.Description,
                    ImageUrl = imageUrl

                };
                
                db.ImageModels.Add(newImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imageModel);
        }

        // GET: ImageModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageModel imageModel = db.ImageModels.Find(id);
            if (imageModel == null)
            {
                return HttpNotFound();
            }
            return View(imageModel);
        }

        // POST: ImageModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Title,Description,ImageUrl,UploadDate")] ImageModel imageModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imageModel);
        }

        // GET: ImageModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageModel imageModel = db.ImageModels.Find(id);
            if (imageModel == null)
            {
                return HttpNotFound();
            }
            return View(imageModel);
        }

        // POST: ImageModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageModel imageModel = db.ImageModels.Find(id);
            db.ImageModels.Remove(imageModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.DynamicData;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ReteaSocialaMDS.Models;
using ReteaSocialaMDS.Models.HomeViewModels;

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

        /// <summary>
        /// Returneaza profilul userului daca acesta exista sau pagina utilizatorului daca userul cu acel id nu exista sau id este null
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Profilul unui user</returns>
        [Authorize]
        [HttpGet]
        public ActionResult UserProfile(string id)
        {
          
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser user;
            UserProfileViewModel model;
            if (id == null)
            {
                //in cazurile astea o sa redirectam pagina catre cea de profil a utilizatorului
                //unde are si setarile
                
                user = userManager.FindById(User.Identity.GetUserId());
                model = new UserProfileViewModel()
                {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    numberOfFriends = user.FriendWith.Count,
                    numberOfImages = user.UserImages.Count,
                    friend = false,
                    friendReq = false,
                    User = id
                };
            }
            else
            {
                user = userManager.FindById(id);
                if (user == null)
                {
                    user = userManager.FindById(User.Identity.GetUserId());
                    
                    model = new UserProfileViewModel()
                    {
                        firstName = user.FirstName,
                        lastName = user.LastName,
                        numberOfFriends = user.FriendWith.Count,
                        numberOfImages = user.UserImages.Count,
                        friend = false,
                        friendReq = false,
                        User = id
                    };
                }
                else
                {
                    
                    string currentUserId=User.Identity.GetUserId().ToString();

                    Friend alreadyFriends = user.IsFriend.FirstOrDefault(fr=> fr.OtherUserId == currentUserId);
                   
                    //trebuia sa fie invers dar nu mai conteaza
                    FriendRequest friendReqAlreadySent = user.SentFriendRequests.FirstOrDefault(fr => fr.FutureFriendUserId == currentUserId);

                    model = new UserProfileViewModel()
                    {
                        firstName = user.FirstName,
                        lastName = user.LastName,
                        numberOfFriends = user.FriendWith.Count,
                        numberOfImages = user.UserImages.Count,
                        friend = alreadyFriends!=null,
                        friendReq = friendReqAlreadySent!=null,
                        User = id
                    };

                }
                    
            }

             
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public JsonResult FriendRequestSend(string otherUserId)
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser friend = userManager.FindById(otherUserId);
            if (friend == null || otherUserId ==User.Identity.GetUserId())
            {
                return Json("-1");
            }

            string currentUserId = User.Identity.GetUserId();

            Friend alreadyFriends = friend.IsFriend.FirstOrDefault(fr => fr.OtherUserId == currentUserId);
            FriendRequest friendReqAlreadySent =
                friend.ReceivedFriendRequests.FirstOrDefault(fr => fr.FutureFriendUserId == currentUserId);

            if (alreadyFriends == null && friendReqAlreadySent==null)
            {
                FriendRequest newFriendRequest = new FriendRequest()
                {
                    UserId = otherUserId,
                    FutureFriendUserId = User.Identity.GetUserId()
                };

                db.FriendRequest.Add(newFriendRequest);
                db.SaveChanges();
            }

            

            return Json("0");
        }

        [Authorize]
        [HttpPost]
        public JsonResult FriendRequests()
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);



            
            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = userManager.FindById(userId);
            IEnumerable<Post> allPosts=currentUser.Posts.ToList();
            List<string> friendReq = (from fr in currentUser.SentFriendRequests select fr.FutureFriendUserId).ToList();
             
                //(from fr in db.FriendRequest where (fr.UserId.CompareTo(userId) ==0 ) select fr.FutureFriendUserId).ToList();
            List<FriendRequestViewModel> futureFriends = new List<FriendRequestViewModel>();
            foreach (string futureFriendUserId in friendReq)
            {
                futureFriends.Add(new FriendRequestViewModel()
                {
                  FutureFriendId  = futureFriendUserId,
                  FirstName =  userManager.FindById(futureFriendUserId).FirstName,
                  SecondName = userManager.FindById(futureFriendUserId).LastName
                });
            }
           
            return Json(futureFriends);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public JsonResult RemoveFriendRequest(string friendId)
        {
            if (friendId == null)
                return Json(null);
            else
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);


                string userId = User.Identity.GetUserId();
                ApplicationUser currentUser = userManager.FindById(userId);
                ApplicationUser friendUser = userManager.FindById(friendId);

                if (currentUser == null || friendUser == null)
                    return Json(null);

                FriendRequest friendRequest =
                    (from fr in currentUser.ReceivedFriendRequests where (fr.UserId == friendId && fr.FutureFriendUserId == userId) select fr).FirstOrDefault();

                if (friendRequest == null)
                    return Json(null);
                db.FriendRequest.Remove(friendRequest);
                db.SaveChanges();




            }
            return Json(1);
        }
        /// <summary>
        ///             
        /// </summary>
        /// <param name="friendId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public JsonResult AcceptFriendRequest(string friendId)
        {
            if (friendId == null)
                return Json(null);
            else
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);


                string userId = User.Identity.GetUserId();
                ApplicationUser currentUser = userManager.FindById(userId);
                ApplicationUser friendUser = userManager.FindById(friendId);

                if (currentUser == null || friendUser == null)
                    return Json(null);

                FriendRequest friendRequest =
                    (from fr in currentUser.ReceivedFriendRequests where (fr.UserId == friendId && fr.FutureFriendUserId == userId) select fr).FirstOrDefault();

                if (friendRequest == null)
                    return Json(null);
                db.FriendRequest.Remove(friendRequest);
                db.SaveChanges();

                Friend one, two;
                one = new Friend()
                {
                    UserId = userId,
                    OtherUserId = friendId
                };
                two = new Friend()
                {
                    UserId = friendId,
                    OtherUserId = userId
                };
                db.Friend.Add(one);
                db.Friend.Add(two);
                db.SaveChanges();


            }
            return Json(1);
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddPost()
        {
            return View(new Post());
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddPost(Post newPost)
        {

            newPost.UserId = User.Identity.GetUserId();
            newPost.PostDate = System.DateTime.Now;

            db.Post.Add(newPost);

            //string userId = User.Identity.GetUserId();
            //DateTime now = System.DateTime.Now;

            //db.Post.Add(new Post()
            //{
            //    UserId = userId,
            //    PostDate = now,
            //    PostMessage = postComment

            //});
            db.SaveChanges();

            //List<string> postAuthors  = (from post in db.Post where (post.UserId.CompareTo(userId) == 0) select post.UserId).ToList();
            //List<DateTime> postDates = (from post in db.Post where (post.UserId.CompareTo(userId) == 0) select post.PostDate).ToList();
            //List<string> postContent = (from post in db.Post where (post.UserId.CompareTo(userId) == 0) select post.PostMessage).ToList();

            return Redirect("/");

        }

        [HttpGet]
        [Authorize]
        public ActionResult Post()
        {

            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = userManager.FindById(userId);
            IEnumerable<Post> allPosts = currentUser.Posts.ToList();

            return View(allPosts);
        }

        

    }
}
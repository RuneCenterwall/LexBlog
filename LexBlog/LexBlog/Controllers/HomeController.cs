using LexBlog.Models;
using LexBlog.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LexBlog.Controllers
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

        public ActionResult GetUserName(string userId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var usr = db.Users.First(user => user.Id == userId);
            return Content(usr.FirstName + " " + usr.LastName);
        }
    }
}
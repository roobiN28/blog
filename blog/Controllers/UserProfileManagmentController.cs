using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using blog.Database;
using blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace blog.Controllers
{
    public class UserProfileManagmentController : Controller
    {

        BlogContext context = new BlogContext();
        // GET: MyAccountTest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            var userId = User.Identity.GetUserId();

            var userProfile = context.UserProfiles.Find(User.Identity.GetUserId());
            if (userProfile == null)
            {

                
                userProfile = new UserProfile(User.Identity.GetUserId());
                context.UserProfiles.Add(userProfile);
                context.SaveChanges();
            }
            userProfile.Name = "Baranek";
            userProfile.BestNumber = 28;

            context.UserProfiles.AddOrUpdate(userProfile);
            context.SaveChanges();




            return View(userProfile);
            
        }

        public ActionResult UserProfileManagment(bool isEditing = false , string returnUrl = "/Post/Table")
        {
            var userProfile = context.UserProfiles.Find(User.Identity.GetUserId());
            if (userProfile == null)
            {
                context.UserProfiles.Add(new UserProfile(User.Identity.GetUserId()));
            }
           
            Session["isEditing"] = isEditing;
            ViewBag.Edit = Session["isEditing"];

            return View(userProfile);

        }

        public ActionResult EditUserProfile(UserProfile user, string returnUrl = "/Post/Table")
        {

            context.UserProfiles.AddOrUpdate(user);

            context.SaveChanges();
            Session["isEditing"] = false;
            return Redirect(returnUrl);
        }

        public ActionResult StartEditing(string returnUrl = "/Post/Table")
        {
            Session["isEditing"] = true;
            return Redirect(returnUrl);
        }
    }
}
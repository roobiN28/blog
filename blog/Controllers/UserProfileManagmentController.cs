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



        public ActionResult UserProfileManagment(bool isEditing = false)
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


        public ActionResult EditUserProfile(UserProfile user, string returnUrl = "/")
        {

            context.UserProfiles.AddOrUpdate(user);

            context.SaveChanges();
            Session["isEditing"] = false;
            return Redirect(returnUrl);
        }


        public ActionResult StartEditing(string returnUrl = "/")
        {
            Session["isEditing"] = true;
            return Redirect(returnUrl);
        }
    }
}
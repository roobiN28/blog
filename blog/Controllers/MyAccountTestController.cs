using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using blog.Database;
using blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace blog.Controllers
{
    public class MyAccountTestController : Controller
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
                context.SaveChangesAsync();
            }
            userProfile.Name = "Baranek";
            userProfile.BestNumber = 28;

            context.UserProfiles.AddOrUpdate(userProfile);
            context.SaveChanges();




            return View(userProfile);
            
        }
    }
}
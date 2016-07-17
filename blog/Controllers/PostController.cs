using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using blog.Database;
using blog.entity;
using Microsoft.AspNet.Identity;

namespace blog.Controllers
{
    public class PostController : Controller
    {


        BlogContext context = new BlogContext();
        private List<Post> posts;

        public ActionResult Table()
        {
            List<Post> posts = context.Posts.ToList();
            return View(posts);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Post post)
        {
            post.DateCreated = DateTime.Now;
            post.Body = post.Body.Replace("\r\n", "<br />");
            post.Author = context.UserProfiles.Find(User.Identity.GetUserId());
            context.Posts.Add(post);
            context.SaveChanges();
            return RedirectToAction("Table");
        }

        [HttpPost]
        public ActionResult AddComment(Comment c, int PostId)
        {
            var post = context.Posts.Find(PostId);
            c.AssignedPost = post;
            c.AddedTime = DateTime.Now;
            c.Author = context.UserProfiles.Find(User.Identity.GetUserId());

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Table");

            }
            context.Comments.Add(c);
            context.SaveChanges();

            return RedirectToAction("Table");

        }
    }
}
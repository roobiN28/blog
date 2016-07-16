using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using blog.Database;
using blog.entity;

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
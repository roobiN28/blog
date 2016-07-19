using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using blog.Models;

namespace blog.entity
{
    public class Post
    {
        public Post()
        {

        }

        public int PostId { get; set; }

        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Ciało posta")]
        public string Body { get; set; }

        public DateTime DateCreated { get; set; }


        public virtual UserProfile Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
      
    }
}
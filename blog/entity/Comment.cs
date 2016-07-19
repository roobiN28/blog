using System;
using System.ComponentModel.DataAnnotations;
using blog.Models;

namespace blog.entity
{
    public class Comment
    {
        public Comment ()
        {
            
        }

        public int CommentId { get; set; }            

        [Required]
        [Display(Name="Komentarz")]
        public string Body { get; set; }
        public DateTime AddedTime { get; set; }
        public virtual Post AssignedPost { get; set; }

        [Display(Name = "Autor")]
        public virtual UserProfile Author { get; set; }
    }
}
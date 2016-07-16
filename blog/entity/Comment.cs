using System;
using System.ComponentModel.DataAnnotations;

namespace blog.entity
{
    public class Comment
    {
        public Comment ()
        {
            
        }

        public int CommentId { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime AddedTime { get; set; }

        public virtual Post AssignedPost { get; set; }


    }
}
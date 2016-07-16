using System.Collections.Generic;

namespace blog.entity
{
    public class Post
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string Author { get; set; }

        public string DateCreated { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
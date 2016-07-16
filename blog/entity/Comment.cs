using System;

namespace blog.entity
{
    public class Comment
    {
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual Post AssignedPost { get; set; }


    }
}
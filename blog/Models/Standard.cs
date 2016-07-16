using System.Collections.Generic;

namespace blog.Models
{
    public class Standard
    {
        public Standard()
        {

        }
        public int StandardId { get; set; }
        public string StandardName { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}
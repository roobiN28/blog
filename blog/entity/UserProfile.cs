namespace blog.Models
{
    public class UserProfile
    {


        public string UserProfileId { get; set; }

        public string Name { get; set; }
        public int BestNumber { get; set; }

        


        public UserProfile(string id)
        {
            this.UserProfileId = id;
        }

        public UserProfile()
        {
        }
    }
}
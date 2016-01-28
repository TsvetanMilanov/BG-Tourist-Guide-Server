namespace BGTouristGuide.Models
{
    using System.Collections.Generic;

    public class Badge
    {
        private ICollection<User> users;

        public Badge()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        public BadgeTitle Title { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
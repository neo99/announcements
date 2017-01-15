using System;

namespace Announcements.Models
{
    public class Announcement
    {
        public Announcement (string content)
        {
            this.Content = content;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        /*
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        */
    }

}

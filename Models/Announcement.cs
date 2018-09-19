using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AnnouncementApp.Models.Attributes;
using Microsoft.AspNetCore.Identity;
//using System.Security.Claims;

namespace AnnouncementApp.Models
{
    public class Announcement
    {
        public int ID { get; set; }
        [Required]
        public string Content { get; set; }
        [Display(Name = "Start Date and Time")]
        public DateTime StartDate { get; set; }
        
        [StartEndDate("End Date and Time must be after Start Date and Time")]
        [Display(Name = "End Date and Time")]
        public DateTime EndDate { get; set; }

        public IdentityUser Owner { get; set; }
    }
}

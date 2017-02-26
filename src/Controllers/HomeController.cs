using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Announcements.Models;
using Announcements.Services;

namespace Announcements.Controllers
{
    public class HomeController : Controller
    {
        AnnouncementService service = new AnnouncementService();

    	[Route("api/{id}.json")]
        [HttpGet]
        public IEnumerable<Announcement> GetJSON()
        {
            return service.List();
        }

    	[Route("api/{id}.js")]
        [HttpGet]
        public string GetJS()
        {
            string result = "";
            IEnumerable<Announcement> announcementList = service.List();
            foreach(Announcement a in announcementList)
            {
                result += "document.write(\"<div>" + a.Content + "</div>\");";
            }
            return result;
        }
    }
}

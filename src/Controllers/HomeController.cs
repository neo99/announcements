using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Announcements.Models;

namespace Announcements.Controllers
{
    public class HomeController : Controller
    {
        IEnumerable<Announcement> announcementList = new Announcement[] {new Announcement("new release on Feb 2, 2017"), new Announcement("emergency fix on Feb 1, 2017")};

    	[Route("api/{id}.json")]
        [HttpGet]
        public IEnumerable<Announcement> GetJSON()
        {
            return announcementList;
        }

    	[Route("api/{id}.js")]
        [HttpGet]
        public string GetJS()
        {
            string result = "";
            foreach(Announcement a in announcementList)
            {
                result += "document.write(\"<div>" + a.Content + "</div>\");";
            }
            return result;
        }
    }
}

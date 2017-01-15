using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Announcements.Models;

namespace Announcements.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IEnumerable<Announcement> Get()
        {
            return new Announcement[] {new Announcement("new release on Feb 2, 2017"), new Announcement("emergency fix on Feb 1, 2017")};
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Announcements.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"new release on Feb 2, 2017", "emergency fix on Feb 1, 2017"};
        }
    }
}

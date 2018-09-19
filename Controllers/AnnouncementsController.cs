using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnnouncementApp.Data;
using AnnouncementApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace AnnouncementApp.Controllers
{
    [Authorize]
    public class AnnouncementsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
				private readonly ILogger _logger;

        public AnnouncementsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<AnnouncementsController> logger)
        {
            _context = context;
            _userManager = userManager;
						_logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> List(string id)
        {
            id = id.Replace(".js","");
            return View(await _context.Announcement.Where(a => a.Owner.Id == id).ToListAsync());
        }

        // GET: Announcements
        public async Task<IActionResult> Index()
        {
            string currentUserId = _userManager.GetUserId(this.User);
            return View(await _context.Announcement.Where(a => a.Owner.Id == currentUserId).ToListAsync());
        }

        // GET: Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcement
                .FirstOrDefaultAsync(m => m.ID == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // GET: Announcements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Content,StartDate,EndDate")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(this.User);
                announcement.Owner = user;
                _context.Add(announcement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcement.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Content,StartDate,EndDate")] Announcement announcement)
        {
            if (id != announcement.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(announcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcement
                .FirstOrDefaultAsync(m => m.ID == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var announcement = await _context.Announcement.FindAsync(id);
            _context.Announcement.Remove(announcement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Announcement.Any(e => e.ID == id);
        }
    }
}

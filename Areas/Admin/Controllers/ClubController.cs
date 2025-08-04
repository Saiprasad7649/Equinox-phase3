using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Equinox.Models;

namespace Equinox.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClubController : Controller
    {
        private readonly EquinoxContext _context;

        public ClubController(EquinoxContext context)
        {
            _context = context;
        }

        // GET: /Admin/Club/Index
        public IActionResult Index()
        {
            var clubs = _context.Clubs.ToList();
            return View(clubs);
        }

        // GET: /Admin/Club/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Club/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Club club)
        {
            if (!ModelState.IsValid)
            {
                TempData["ModelError"] = "Please correct the errors and try again.";
                return View(club);
            }

            _context.Clubs.Add(club);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Club/Edit/{id}
        public IActionResult Edit(int id)
        {
            var club = _context.Clubs.Find(id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // POST: /Admin/Club/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Club club)
        {
            if (!ModelState.IsValid)
            {
                TempData["ModelError"] = "Please correct the errors and try again.";
                return View(club);
            }

            _context.Entry(club).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Club/Delete/{id}
        public IActionResult Delete(int id)
        {
            var club = _context.Clubs.Find(id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // POST: /Admin/Club/DeleteConfirmed/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var club = _context.Clubs.Find(id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

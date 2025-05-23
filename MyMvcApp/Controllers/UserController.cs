using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Data;
using MyMvcApp.Models;
using System.Linq;

namespace MyMvcApp.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: User
        public IActionResult Index(string? searchString)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                users = users.Where(u =>
                    u.Name.Contains(searchString) ||
                    u.Email.Contains(searchString) ||
                    u.Phone.Contains(searchString)
                );
            }
            return View(users.ToList());
        }

        // GET: User/Details/5
        public IActionResult Details(int? id)
        {
            // Show details for a user
            if (id == null) return NotFound();
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            // Show create form
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Email,Phone")] User user)
        {
            // Add new user
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public IActionResult Edit(int? id)
        {
            // Show edit form
            if (id == null) return NotFound();
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Email,Phone")] User user)
        {
            // Update user
            if (id != user.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/5
        public IActionResult Delete(int? id)
        {
            // Show delete confirmation
            if (id == null) return NotFound();
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete user
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

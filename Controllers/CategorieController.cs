using Microsoft.AspNetCore.Mvc;
using TP11Core.Models;
using System.Linq;

namespace TP11Core.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategorieController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorie categorie)
        {
            _context.Categories.Add(categorie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) NotFound();
            var cat = _context.Categories.Find(id);
            return View(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorie cat)

        {
            _context.Categories.Update(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) NotFound();
            var cat = _context.Categories.Find(id);
            return View(cat);
        }
        [HttpPost]
        public IActionResult Delete2(int? id)
        {
            if (id == null) NotFound();
            var cat = _context.Categories.Find(id);
            _context.Categories.Remove(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
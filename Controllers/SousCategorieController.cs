using Microsoft.AspNetCore.Mvc;
using TP11Core.Models;
namespace TP11Core.Controllers
{
    public class SousCategorieController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SousCategorieController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index()

        {
            var souscategories = _context.SousCategories.ToList();
            return View(souscategories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SousCategorie sousCategorie)
        {
            if (ModelState.IsValid)
            {
                _context.SousCategories.Add(sousCategorie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sousCategorie);
        }
    }
}
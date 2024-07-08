using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP11Core.Models;

namespace TP11Core.Controllers
{
    public class ProduitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProduitController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produits = _context.Produits.Include(p => p.CategorieProduits)
                                             .ThenInclude(cp => cp.Categorie)
                                             .ToList();
            return View(produits);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produit produit, int[] categorieIds)
        {
            if (ModelState.IsValid)
            {
                foreach (var categorieId in categorieIds)
                {
                    var categorieProduit = new CategorieProduit
                    {
                        CategorieId = categorieId,
                        Produit = produit
                    };
                    _context.CategorieProduits.Add(categorieProduit);
                }
                _context.Produits.Add(produit);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(produit);
        }
    }
}

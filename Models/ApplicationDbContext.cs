using Microsoft.EntityFrameworkCore;
namespace TP11Core.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options){}

        public DbSet<Categorie> Categories { get; set; }
        public DbSet<SousCategorie> SousCategories { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<CategorieProduit> CategorieProduits { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategorieProduit>()
                .HasKey(cp => new { cp.CategorieId, cp.ProduitId });

            modelBuilder.Entity<CategorieProduit>()
                .HasOne(cp => cp.Categorie)
                .WithMany(c => c.CategorieProduits)
                .HasForeignKey(cp => cp.CategorieId);

            modelBuilder.Entity<CategorieProduit>()
                .HasOne(cp => cp.Produit)
                .WithMany(p => p.CategorieProduits)
                .HasForeignKey(cp => cp.ProduitId);
        }
    }
}
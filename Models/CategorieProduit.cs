namespace TP11Core.Models
{
    public class CategorieProduit
    {
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
    }
}

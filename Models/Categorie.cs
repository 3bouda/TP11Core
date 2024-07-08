namespace TP11Core.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<SousCategorie> sousCategories { get; set; }
        public ICollection<CategorieProduit> CategorieProduits { get; set; }
    }
}

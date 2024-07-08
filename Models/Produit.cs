namespace TP11Core.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategorieProduit> CategorieProduits { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace TP11Core.Models
{
    public class SousCategorie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("CategorieId")]
        public Categorie Categorie { get; set; }
    }
}

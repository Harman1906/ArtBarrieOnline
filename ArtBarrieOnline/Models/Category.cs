using System.ComponentModel.DataAnnotations;

namespace ArtBarrieOnline.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Art>? Arts { get; set; }
    }
}

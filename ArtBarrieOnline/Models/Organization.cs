using System.ComponentModel.DataAnnotations;

namespace ArtBarrieOnline.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Art>? Arts { get; set; }
    }
}

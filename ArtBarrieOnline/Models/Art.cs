using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtBarrieOnline.Models
{
    public class Art
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]
        public string? Pic { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date_Added { get; set; }

        public string? CategoryId { get; set; }

        public string? OrganizationId { get; set;}


        public Category Category { get; set; }

        public Organization Organization { get; set; }
    }
}

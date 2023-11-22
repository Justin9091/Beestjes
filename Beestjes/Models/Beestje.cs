using System.ComponentModel.DataAnnotations;

namespace Beestjes.Models
{
    public class Beestje
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name can only contain alphabetical letters")]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [Range(1, 1000000, ErrorMessage = "Price must be between 1 and 1,000,000")]
        public int Price { get; set; }

        public string? Image { get; set; }
    }

}

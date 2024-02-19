using System.ComponentModel.DataAnnotations;

namespace ePharma_asp_mvc.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public bool NeedsPrescription { get; set; }

    }
}

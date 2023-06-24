using System.ComponentModel.DataAnnotations;

namespace ProdavnicaPiva.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Manufacture")]
        public string Name { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace ProdavnicaPiva.Models
{
    public class Distributor
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Distributor")]
        public string Name { get; set; }

    }
}
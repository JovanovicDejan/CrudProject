using System.ComponentModel.DataAnnotations;

namespace ProdavnicaPiva.Dtos
{
    public class BeerDto
    {
        public int Id { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int DistributorId { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
    }
}
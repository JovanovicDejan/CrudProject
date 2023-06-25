using System.ComponentModel.DataAnnotations;

namespace ProdavnicaPiva.Dtos
{
    public class DistributorDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
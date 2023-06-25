using System.ComponentModel.DataAnnotations;

namespace ProdavnicaPiva.Dtos
{
    public class ManufacturerDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int PIB { get; set; }
    }
}
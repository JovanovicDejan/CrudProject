using System;
using System.ComponentModel.DataAnnotations;

namespace ProdavnicaPiva.Dtos
{
    public class BrandDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateMade { get; set; }
    }
}
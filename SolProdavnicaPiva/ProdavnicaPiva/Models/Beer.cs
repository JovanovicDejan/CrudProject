using System.ComponentModel.DataAnnotations;

namespace ProdavnicaPiva.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public Brand Brand { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        public Distributor Distributor { get; set; }

        [Required]
        [Display(Name = "Distributor")]
        public int DistributorId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        [Required]
        [Display(Name = "Manufacture")]
        public int ManufacturerId { get; set; }

    }
}
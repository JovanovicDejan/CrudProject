﻿using System.ComponentModel.DataAnnotations;

namespace ProdavnicaPiva.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public string Name { get; set; }

    }
}
using ProdavnicaPiva.Models;
using System.Collections.Generic;

namespace ProdavnicaPiva.ViewModels
{
    public class BeerViewModel
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Distributor> Distributors { get; set; }

        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public Beer Beer { get; set; }
    }
}
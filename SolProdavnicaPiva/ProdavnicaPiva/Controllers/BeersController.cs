using ProdavnicaPiva.Models;
using ProdavnicaPiva.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProdavnicaPiva.Controllers
{
    [Authorize]
    public class BeersController : Controller
    {
        private ApplicationDbContext _context;

        public BeersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Beers
        [AllowAnonymous]
        public ActionResult Index()
        {
            var beers = _context.Beers.Include(b => b.Brand).Include(d => d.Distributor).Include(m => m.Manufacturer).ToList();
            if (User.IsInRole(RoleName.CanManageBrands))
            {
                if (beers == null)
                    return HttpNotFound();

                return View(beers);
            }
            else
            {
                return View("ReadOnlyList", beers);
            }
        }

        [Authorize]
        // GET: Beer
        public ActionResult Edit(int id)
        {
            var beer = _context.Beers.Include(b => b.Brand).Include(d => d.Distributor).Include(m => m.Manufacturer).SingleOrDefault(b => b.Id == id);
            if (beer == null)
                return HttpNotFound();

            var beerViewModel = new BeerViewModel
            {
                Beer = beer,
                Distributors = _context.Distributors.ToList(),
                Brands = _context.Brands.ToList(),
                Manufacturers = _context.Manufacturers.ToList()
            };


            return View("BeerForm", beerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Save(Beer beer)
        {

            if (!ModelState.IsValid)
            {
                var beerViewModel = new BeerViewModel
                {
                    Beer = beer,
                    Distributors = _context.Distributors.ToList(),
                    Brands = _context.Brands.ToList(),
                    Manufacturers = _context.Manufacturers.ToList()
                };
                return View("BeerForm", beerViewModel);
            }
            int id = beer.Id;
            if (beer.Id == 0)
            {
                _context.Beers.Add(beer);
            }
            else
            {
                var beerInDb = _context.Beers.Single(b => b.Id == beer.Id);

                beerInDb.BrandId = beer.BrandId;
                beerInDb.DistributorId = beer.DistributorId;
                beerInDb.ManufacturerId = beer.ManufacturerId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Beers");
        }
        [Authorize(Roles = RoleName.CanManageBrands)]
        public ActionResult New()
        {
            var distributors = _context.Distributors.ToList();
            var brands = _context.Brands.ToList();
            var manufacturers = _context.Manufacturers.ToList();

            var beerViewModel = new BeerViewModel
            {
                Beer = new Beer(),
                Distributors = distributors,
                Brands = brands,
                Manufacturers = manufacturers
            };
            return View("BeerForm", beerViewModel);
        }
    }
}
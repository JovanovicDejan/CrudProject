using ProdavnicaPiva.Models;
using ProdavnicaPiva.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ProdavnicaPiva.Controllers
{
    public class BrandsController : Controller
    {
        private ApplicationDbContext _context;

        public BrandsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Brands
        public ActionResult Index()
        {
            var brands = _context.Brands.ToList();
            if (brands == null)
                return HttpNotFound();

            return View(brands);
        }

        [HttpPost]
        public ActionResult Save(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                var brandViewModel = new BrandViewModel { Brand = brand };
                return View("BrandForm", brandViewModel);
            }
            if (brand.Id == 0)
            {
                _context.Brands.Add(brand);
            }
            else
            {
                var brandInDb = _context.Brands.Single(b => b.Id == brand.Id);
                brandInDb.Name = brand.Name;
                brandInDb.DateMade = brand.DateMade;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Brands");
        }

        public ActionResult New()
        {
            var brandViewModel = new BrandViewModel
            {
                Brand = new Brand()
            };

            return View("BrandForm", brandViewModel);
        }

        public ActionResult Edit(int id)
        {
            var brand = _context.Brands.SingleOrDefault(b => b.Id == id);

            if (brand == null)
                return HttpNotFound();

            var brandViewModel = new BrandViewModel { Brand = brand };

            return View("BrandForm", brandViewModel);
        }
    }
}
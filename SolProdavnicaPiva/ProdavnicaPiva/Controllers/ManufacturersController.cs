using ProdavnicaPiva.Models;
using ProdavnicaPiva.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ProdavnicaPiva.Controllers
{
    public class ManufacturersController : Controller
    {
        // GET: Manufacturers
        private ApplicationDbContext _context;

        public ManufacturersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Brands
        public ActionResult Index()
        {
            var manufacturer = _context.Manufacturers.ToList();
            if (manufacturer == null)
                return HttpNotFound();

            return View(manufacturer);
        }

        [HttpPost]
        public ActionResult Save(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                var manufacturerViewModel = new ManufacturerViewModel { Manufacturer = manufacturer };
                return View("ManufacturerForm", manufacturerViewModel);
            }
            if (manufacturer.Id == 0)
            {
                _context.Manufacturers.Add(manufacturer);
            }
            else
            {
                var manufacturerInDb = _context.Manufacturers.Single(b => b.Id == manufacturer.Id);
                manufacturerInDb.Name = manufacturer.Name;
                manufacturerInDb.PIB = manufacturer.PIB;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Manufacturers");
        }

        public ActionResult New()
        {
            var manufacturerViewModel = new ManufacturerViewModel
            {
                Manufacturer = new Manufacturer()
            };

            return View("ManufacturerForm", manufacturerViewModel);
        }

        public ActionResult Edit(int id)
        {
            var manufacturer = _context.Manufacturers.SingleOrDefault(b => b.Id == id);

            if (manufacturer == null)
                return HttpNotFound();

            var manufacturerViewModel = new ManufacturerViewModel { Manufacturer = manufacturer };

            return View("ManufacturerForm", manufacturerViewModel);
        }
    }
}
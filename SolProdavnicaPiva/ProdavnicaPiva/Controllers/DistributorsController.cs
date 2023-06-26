using ProdavnicaPiva.Models;
using ProdavnicaPiva.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ProdavnicaPiva.Controllers
{
    [Authorize(Roles = RoleName.CanManageBrands)]
    public class DistributorsController : Controller
    {
        // GET: Distributor
        private ApplicationDbContext _context;

        public DistributorsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Brands
        [AllowAnonymous]

        public ActionResult Index()
        {
            var distributor = _context.Distributors.ToList();
            if (distributor == null)
                return HttpNotFound();

            if (User.IsInRole(RoleName.CanManageBrands))
                return View(distributor);
            return View("ReadOnlyList", distributor);
        }

        [HttpPost]
        public ActionResult Save(Distributor distributor)
        {
            if (!ModelState.IsValid)
            {
                var distributorViewModel = new DistributorViewModel { Distributor = distributor };
                return View("DistributorForm", distributorViewModel);
            }
            if (distributor.Id == 0)
            {
                _context.Distributors.Add(distributor);
            }
            else
            {
                var distributorInDb = _context.Distributors.Single(b => b.Id == distributor.Id);
                distributorInDb.Name = distributor.Name;
                distributorInDb.Country = distributor.Country;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Distributors");
        }

        public ActionResult New()
        {
            var distributorViewModel = new DistributorViewModel
            {
                Distributor = new Distributor()
            };

            return View("DistributorForm", distributorViewModel);
        }

        public ActionResult Edit(int id)
        {
            var distributor = _context.Distributors.SingleOrDefault(b => b.Id == id);

            if (distributor == null)
                return HttpNotFound();

            var distributorViewModel = new DistributorViewModel { Distributor = distributor };

            return View("DistributorForm", distributorViewModel);
        }
    }
}
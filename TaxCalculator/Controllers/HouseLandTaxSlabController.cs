using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaxCalculator.DAL;
using TaxCalculator.Models;

namespace TaxCalculator.Controllers
{
    public class HouseLandTaxSlabController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();

        // GET: HouseValuation
        public ActionResult Index()
        {
            var houseLandTaxSlabs = db.HouseLandTaxSlabs.ToList();

            return View(houseLandTaxSlabs);
        }
        
        public ActionResult New()
        {
            var houseLandTaxSlab = new HouseLandTaxSlab();

            return View("HouseLandTaxSlabForm", houseLandTaxSlab);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(HouseLandTaxSlab model)
        {

            if (!ModelState.IsValid)
            {
                var invalidModel = model;
                return View("HouseLandTaxSlabForm", invalidModel);

            }


            if (model.Id == 0)
            {
                db.HouseLandTaxSlabs.Add(model);
            }
            else
            {
                var houseLandTaxInDB = db.HouseLandTaxSlabs.Single(h => h.Id == model.Id);
                houseLandTaxInDB.Sequence = model.Sequence;
                houseLandTaxInDB.UpperLimit = model.UpperLimit;
                houseLandTaxInDB.LowerLimit = model.LowerLimit;
                houseLandTaxInDB.TaxAmount = model.TaxAmount;
                houseLandTaxInDB.TaxPercent = model.TaxPercent;
                houseLandTaxInDB.FirstSlab = model.FirstSlab;
            }

            db.SaveChanges();
            return RedirectToAction("Index", "HouseLandTaxSlab");
        }


        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        
            var houseLandTaxSlab = db.HouseLandTaxSlabs.Find(Id);

            if (houseLandTaxSlab == null)
            {
                return HttpNotFound();
            }

           

            ViewBag.title = "Edit";

            return View("HouseLandTaxSlabForm", houseLandTaxSlab);
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            HouseLandTaxSlab houseLandTaxSlab = db.HouseLandTaxSlabs.Find(Id);
            if (houseLandTaxSlab == null)
            {
                return HttpNotFound();
            }

          
            //return View(citizen);
            return View(houseLandTaxSlab);
        }





    }
}
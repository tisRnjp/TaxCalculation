using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaxCalculator.DAL;
using TaxCalculator.Models;

namespace TaxCalculator.Controllers
{
    public class HouseValuationController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();

        // GET: HouseValuation
        public ActionResult Index()
        {
            var houseValuations = db.HouseValuations.ToList();

            return View(houseValuations);
        }
        
        public ActionResult New()
        {
            var houseValuation = new HouseValuation();

            return View("HouseValuationForm",houseValuation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(HouseValuation model)
        {

            if (!ModelState.IsValid)
            {
                var invalidModel = model;
                return View("HouseValuationForm", invalidModel);

            }


            if (model.Id == 0)
            {
                db.HouseValuations.Add(model);
            }
            else
            {
                var houseValuationInDB = db.HouseValuations.Single(h => h.Id == model.Id);
                houseValuationInDB.Description = model.Description;
                houseValuationInDB.CostPerArea = model.CostPerArea;
                houseValuationInDB.DepreciationRate = model.DepreciationRate;
                houseValuationInDB.DepreciationPeriod = model.DepreciationPeriod;
            }

            db.SaveChanges();
            return RedirectToAction("Index", "HouseValuation");
        }


        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        
            var houseValuation = db.HouseValuations.Find(Id);

            if (houseValuation == null)
            {
                return HttpNotFound();
            }

           

            ViewBag.title = "Edit";

            return View("HouseValuationForm", houseValuation);
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            HouseValuation houseValuation = db.HouseValuations.Find(Id);
            if (houseValuation == null)
            {
                return HttpNotFound();
            }

          
            //return View(citizen);
            return View(houseValuation);
        }





    }
}
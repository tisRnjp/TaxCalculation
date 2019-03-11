using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaxCalculator.DAL;
using System.Data.Entity;
using TaxCalculator.Models;

namespace TaxCalculator.Controllers
{
    [Authorize]
    public class HouseValuationController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();

        // GET: HouseValuation
        public ActionResult Index()
        {
            var houseValuations = db.HouseValuations.Include(h => h.FiscalYear);

            return View(houseValuations);
        }
        
        public ActionResult New()
        {
            var houseValuation = new HouseValuation();
            ViewBag.FiscalYears = new SelectList(db.FiscalYears.ToList(), "Id", "FY");
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
                houseValuationInDB.FiscalYearId = model.FiscalYearId;
                houseValuationInDB.LastFYCostPerArea = model.LastFYCostPerArea;
                houseValuationInDB.LastFYDepreciationRate = model.LastFYDepreciationRate;
                houseValuationInDB.LastFYDepreciationPeriod = model.LastFYDepreciationPeriod;

            }

            db.SaveChanges();
            return RedirectToAction("Index", "HouseValuation");
        }

        // POST: PersonalDetails/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            HouseValuation houseValuation = db.HouseValuations.Find(id);
            db.HouseValuations.Remove(houseValuation);
            db.SaveChanges();
            return RedirectToAction("Index");
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

           

            ViewBag.title = "घर को मुल्यांकन";
            ViewBag.FiscalYears = new SelectList(db.FiscalYears.ToList(), "Id", "FY");
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
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaxCalculator.DAL;
using TaxCalculator.Models;

namespace TaxCalculator.Controllers
{
    public class FiscalYearController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();

        // GET: HouseValuation
        public ActionResult Index()
        {
            var fiscalYears = db.FiscalYears.ToList();

            return View(fiscalYears);
        }
        
        public ActionResult New()
        {
            var fiscalYears = new FiscalYear();

            return View("FiscalYearForm", fiscalYears);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(FiscalYear model)
        {

            if (!ModelState.IsValid)
            {
                var invalidModel = model;
                return View("FiscalYearForm", invalidModel);

            }


            if (model.Id == 0)
            {
                db.FiscalYears.Add(model);
            }
            else
            {
                var fiscalYearInDB = db.FiscalYears.Single(h => h.Id == model.Id);
                fiscalYearInDB.FY = model.FY;
            }

            db.SaveChanges();
            return RedirectToAction("Index", "FiscalYear");
        }


        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        
            var fiscalYear = db.FiscalYears.Find(Id);

            if (fiscalYear == null)
            {
                return HttpNotFound();
            }

           

            ViewBag.title = "Edit";

            return View("FiscalYearForm", fiscalYear);
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            FiscalYear fiscalYear = db.FiscalYears.Find(Id);
            if (fiscalYear == null)
            {
                return HttpNotFound();
            }

          
            //return View(citizen);
            return View(fiscalYear);
        }





    }
}
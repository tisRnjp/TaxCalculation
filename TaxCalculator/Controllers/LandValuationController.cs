using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaxCalculator.DAL;
using TaxCalculator.Models;

namespace TaxCalculator.Controllers
{
    public class LandValuationController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();

        // GET: landValuation
        public ActionResult Index()
        {
            var landValuations = db.LandValuations.ToList();

            return View(landValuations);
        }
        
        public ActionResult New()
        {
            var landValuation = new LandValuation();

            return View("LandValuationForm",landValuation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(LandValuation model)
        {

            if (!ModelState.IsValid)
            {
                var invalidModel = model;
                return View("LandValuationForm", invalidModel);

            }


            if (model.Id == 0)
            {
                db.LandValuations.Add(model);
            }
            else
            {
                var landValuationInDB = db.LandValuations.Single(h => h.Id == model.Id);
                landValuationInDB.Description = model.Description;
                landValuationInDB.LandType = model.LandType;
                landValuationInDB.CostPerAnna = model.CostPerAnna;
                
            }

            db.SaveChanges();
            return RedirectToAction("Index", "LandValuation");
        }


        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        
            var landValuation = db.LandValuations.Find(Id);

            if (landValuation == null)
            {
                return HttpNotFound();
            }

           

            ViewBag.title = "Edit";

            return View("LandValuationForm", landValuation);
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            LandValuation landValuation = db.LandValuations.Find(Id);
            if (landValuation == null)
            {
                return HttpNotFound();
            }

          
            //return View(citizen);
            return View(landValuation);
        }





    }
}
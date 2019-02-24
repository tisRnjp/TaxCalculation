using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TaxCalculator.DAL;
using TaxCalculator.Models;
using TaxCalculator.ViewModels;

namespace TaxCalculator.Controllers
{
    public class LandTaxController : Controller
    {

        private CitizenDbContext db = new CitizenDbContext();
        // GET: LandTax
        public ActionResult Index()
        {
            var landTaxHistories = db.LandTaxHistories.Include(c => c.CitizenLand).ToList();
            var landTaxViewModel = new LandTaxViewModel
            {
                LandTaxHistories = landTaxHistories
            };

            return View(landTaxViewModel);
        }

     

        public ActionResult LandTax(int? CitizenId)
        {

            var citizenLand = db.CitizenLands.First(c => c.CitizenId == CitizenId);
            var landTaxViewModel = new LandTaxViewModel
            {
                
                CitizenLand = db.CitizenLands.First(c => c.CitizenId == CitizenId),
                LandTaxHistory = new LandTaxHistory { CitizenId = CitizenId,
                                    ValuationArea = citizenLand.ValuationArea,
                                    CitizenLandId = citizenLand.Id},
                CitizenLands = db.CitizenLands.ToList(),
                Citizens = db.Citizens.ToList()

            };
            
            return View("LandTaxCalculationForm",landTaxViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(LandTaxViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                var invalidViewModel = new LandTaxViewModel
                {
                    LandTaxHistory = viewModel.LandTaxHistory, 
                };
                return View("LandTaxCalculationForm", invalidViewModel);

            }


            if (viewModel.LandTaxHistory.Id == 0)
            {
                db.LandTaxHistories.Add(viewModel.LandTaxHistory);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "LandTax");
        }
    }
}
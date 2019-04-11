using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaxCalculator.DAL;
using TaxCalculator.Models;
using TaxCalculator.ViewModels;

namespace TaxCalculator.Controllers
{
    [Authorize]
    public class HouseTaxController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();

        // GET: HouseTax
        public ActionResult Index(int? id)
        {
            var houseTaxes = new HouseTaxViewModel {
                HouseTaxHistories = db.HouseTaxHistories.Include(h => h.CitizenHouse).ToList()
            };

            return View(houseTaxes);
        }

        // GET: HouseTax/Create
        [HttpGet]
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            var landTaxHistory = db.LandTaxHistories
                                    .OrderByDescending(l => l.Id)
                                    .FirstOrDefault(l => l.CitizenId == id);
            if (landTaxHistory == null)
            {
                landTaxHistory = new LandTaxHistory();
            }        

            var fromFY = landTaxHistory.Id != 0 ? db.FiscalYears
                                                    .OrderByDescending(l => l.Id)
                                                    .FirstOrDefault(l => l.Id == (landTaxHistory.ToFiscalYearId + 1))
                                                    : db.FiscalYears
                                                        .OrderByDescending(l => l.Id)
                                                        .FirstOrDefault(l => l.FY == "75/76");

            var toFY = db.FiscalYears
                            .OrderByDescending(l => l.Id)
                            .FirstOrDefault(l => l.FY == "75/76");

            //Needs Working CitienHouse Must have citizen ID...................................................................
            var citizenHouse = db.CitizenHouses.Single(h => h.CitizenId == id);
            var houseTax = new HouseTaxViewModel();

            if (citizenHouse != null)
            {
                houseTax.CitizenHouse = citizenHouse;
                houseTax.HouseTax = new HouseTaxHistory {
                                                CitizenHouseId = citizenHouse.Id,
                                                TotalArea = citizenHouse.Area,
                                                FromFiscalYearId = fromFY.Id,
                                                ToFiscalYearId = toFY.Id,

                };
                houseTax.HouseValuations = db.HouseValuations.ToList();
                houseTax.FiscalYears = db.FiscalYears.ToList();
            }
            
            return View(houseTax);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HouseTaxViewModel model)
        {

            var fiscalYear = db.FiscalYears.First(c => c.Id == model.HouseTax.FromFiscalYearId);
            model.HouseTax.FromFY = fiscalYear.FY;
            model.HouseTax.TotalYears = fiscalYear.Sequence;
            fiscalYear = db.FiscalYears.First(c => c.Id == model.HouseTax.ToFiscalYearId);
            model.HouseTax.ToFY = fiscalYear.FY;
            model.HouseTax.TotalYears = fiscalYear.Sequence - model.HouseTax.TotalYears;
            db.HouseTaxHistories.Add(model.HouseTax);

           
            
            var citizenHouse = db.CitizenHouses.First(c => c.Id == model.HouseTax.CitizenHouseId);
            
            db.SaveChanges();
            
            
            //Move to land calculations

            
            var citizenLand = db.CitizenLands.First(c => c.CitizenId == citizenHouse.CitizenId);
            var landTaxViewModel = new LandTaxViewModel();
            if (citizenLand != null)
            {
                landTaxViewModel.CitizenLand = citizenLand;
                landTaxViewModel.LandTaxHistory = new LandTaxHistory
                {
                    CitizenId = citizenHouse.CitizenId,
                    //ValuationArea = citizenLand.ValuationArea,
                    ValuationArea = model.HouseTax.TotalArea / 1.75m / 342.25m,
                    ActualValuationArea = citizenLand.ValuationArea,
                    CitizenLandId = citizenLand.Id,
                    HouseTaxHistoryId = model.HouseTax.Id,
                    FromFiscalYearId = model.HouseTax.FromFiscalYearId,
                    ToFiscalYearId = model.HouseTax.ToFiscalYearId,
                    ToFY = model.HouseTax.ToFY,
                    FromFY = model.HouseTax.FromFY,
                    KittaNo = citizenLand.KittaNo


                };
                landTaxViewModel.CitizenLands = db.CitizenLands.ToList();
                landTaxViewModel.Citizens = db.Citizens.ToList();
                landTaxViewModel.LandValuations = db.LandValuations.ToList();
                landTaxViewModel.FiscalYears = db.FiscalYears.ToList();

            }
            
            return View("~/Views/LandTax/LandTaxCalculationForm.cshtml", landTaxViewModel);
        }

        public ActionResult GetHouseValuation(string category)
        {
            if (!string.IsNullOrWhiteSpace(category) && category.Length == 1)
            {
                var houseValuation = db.HouseValuations.Single(m => m.HouseType == category);

                return Json(houseValuation, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public ActionResult GetDepreciationRate(string category,int? id)
        {
            var landTaxHistory = db.LandTaxHistories
                                    .OrderByDescending(h => h.Id)
                                    .FirstOrDefault(h => h.CitizenId == id);
            var houseTaxHistory = db.HouseTaxHistories
                                    .OrderByDescending(h => h.Id)
                                    .FirstOrDefault(h => h.Id == landTaxHistory.HouseTaxHistoryId);
            if (!string.IsNullOrWhiteSpace(category) && category.Length == 1)
            {
                var houseValuation = db.HouseValuations.Single(m => m.HouseType == category);
                if (houseTaxHistory != null)
                {
                    var Rate = new { rate = houseValuation.DepreciationRate, lastRate = houseTaxHistory.DepreciationRate };
                    return Json(Rate, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var Rate = new { rate = 0, lastRate = 0 };
                    return Json(Rate, JsonRequestBehavior.AllowGet);
                }
                
            }
            return null;
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

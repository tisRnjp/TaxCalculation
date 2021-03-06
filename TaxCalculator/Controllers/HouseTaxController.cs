﻿using System;
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
                return RedirectToAction("Index", "CitizenHouse");
            }

            var citizenHouse = db.CitizenHouses.Single(h => h.Id == id);
            var houseTax = new HouseTaxViewModel();
            if(citizenHouse != null)
            {
                houseTax.CitizenHouse = citizenHouse;
                houseTax.HouseTax = new HouseTaxHistory { CitizenHouseId = citizenHouse.Id, TotalArea = citizenHouse.Area};
            }

            return View(houseTax);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HouseTaxViewModel model)
        {
            
            db.HouseTaxHistories.Add(model.HouseTax);
            var citizenHouse = db.CitizenHouses.First(c => c.Id == model.HouseTax.CitizenHouseId);

            db.SaveChanges();

            
            //Move to land calculations
            var citizenLand = db.CitizenLands.First(c => c.CitizenId == citizenHouse.CitizenId);
            var landTaxViewModel = new LandTaxViewModel
            {

                CitizenLand = db.CitizenLands.First(c => c.CitizenId == citizenHouse.CitizenId),
                LandTaxHistory = new LandTaxHistory
                {
                    CitizenId = citizenHouse.CitizenId,
                    ValuationArea = citizenLand.ValuationArea,
                    CitizenLandId = citizenLand.Id,
                    HouseTaxHistoryId = model.HouseTax.Id

                },
                CitizenLands = db.CitizenLands.ToList(),
                Citizens = db.Citizens.ToList()

            };

            return View("~/Views/LandTax/LandTaxCalculationForm.cshtml", landTaxViewModel);

          
          
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

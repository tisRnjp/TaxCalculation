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

namespace TaxCalculator.Controllers
{
    public class HouseTaxController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();

        // GET: HouseTax
        public ActionResult Index(int? id)
        {
            var houseTaxes = new HouseTaxViewModel();

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
                houseTax.HouseTax = new HouseTaxHistory { CitizenHouseId = citizenHouse.Id};
            }

            return View(houseTax);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HouseTaxViewModel model)
        {
            
            db.HouseTaxHistories.Add(model.HouseTax);
            db.SaveChanges();

            return RedirectToAction("Index");
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

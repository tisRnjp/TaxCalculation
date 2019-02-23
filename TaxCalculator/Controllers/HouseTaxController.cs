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
        public ActionResult Index(int id)
        {

            //var citizen = db.Citizens.Single(c => c.CitizenId == id);  RM
            //var citizenHouse = db.CitizenHouses.Where(h => h.Id == citizen.CitizenId); RM
            //var propertyType = db.PropertyType.Single(r => r.FiscalYear == "74/75" && r.Type == "House");

            //var houseTaxes = new List<HouseTaxViewModel>();  //RM
            var houseTaxes = new HouseTaxViewModel {
                HouseTaxHistories = db.HouseTaxHistories.ToList()
                

            };

            //foreach (var house in citizenHouse)
            //{
            //    houseTaxes.Add(new HouseTaxViewModel   //RM
            //    {
            //        CitizenHouse = house,
            //        CurrentCost = 12000,
            //        DepreciationRate = propertyType.DepriciationRate,
            //        LastYearCost = 11500,
            //    });

              


            //}




            return View(houseTaxes);
        }

        // GET: HouseTax/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseTaxViewModel houseTaxViewModel = db.HouseTaxViewModels.Find(id);
            if (houseTaxViewModel == null)
            {
                return HttpNotFound();
            }
            return View(houseTaxViewModel);
        }

        // GET: HouseTax/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseTax/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CurrentCost,DepreciationRate,LastYearCost")] HouseTaxViewModel houseTaxViewModel)
        {
            if (ModelState.IsValid)
            {
                db.HouseTaxViewModels.Add(houseTaxViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(houseTaxViewModel);
        }

        // GET: HouseTax/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseTaxViewModel houseTaxViewModel = db.HouseTaxViewModels.Find(id);
            if (houseTaxViewModel == null)
            {
                return HttpNotFound();
            }
            return View(houseTaxViewModel);
        }

        // POST: HouseTax/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CurrentCost,DepreciationRate,LastYearCost")] HouseTaxViewModel houseTaxViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houseTaxViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(houseTaxViewModel);
        }

        // GET: HouseTax/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseTaxViewModel houseTaxViewModel = db.HouseTaxViewModels.Find(id);
            if (houseTaxViewModel == null)
            {
                return HttpNotFound();
            }
            return View(houseTaxViewModel);
        }

        // POST: HouseTax/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseTaxViewModel houseTaxViewModel = db.HouseTaxViewModels.Find(id);
            db.HouseTaxViewModels.Remove(houseTaxViewModel);
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

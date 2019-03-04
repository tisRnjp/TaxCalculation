using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaxCalculator.DAL;
using TaxCalculator.Models;


namespace TaxCalculator.Controllers
{
    [Authorize]
    public class ZoneController : Controller
    {

        private CitizenDbContext db = new CitizenDbContext();

        // GET: Zone
        public ActionResult Index()
        {
            var zones = db.Zones.ToList();
            //if (Search_Data != null)
            //{
            //    citizens = db.Citizens
            //                   .Where(c => c.FirstName.Contains(Search_Data) | c.LastName.Contains(Search_Data))
            //                   .ToList();
            //}



            //var citizenViewModel = new SearchCitizenViewModel
            //{
            //    Citizens = citizens
            //};

            return View(zones);
        }

        // GET: Zone/Details/5
        public ActionResult Details(int id)
        {

            Zone zone = db.Zones.Find(id);
            if (zone == null)
            {
                return HttpNotFound();
            }
            
            return View(zone);
        }
        [HttpPost]
        public ActionResult Save(Zone zone)
        {

            if (zone.Id == 0)
            {
                db.Zones.Add(zone);
            }
            else
            {
                var zoneInDB = db.Zones.Single(c => c.Id == zone.Id);
                zoneInDB.Code = zone.Code;
                zoneInDB.Description = zone.Description;
              
            }

            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // GET: Zone/Create
        public ActionResult Create()
        {
            return View("EditZone");
        }

        // POST: Zone/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zone/Edit/5
        public ActionResult Edit(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            var zone = db.Zones.Find(id);

            if (zone == null)
            {
                return HttpNotFound();
            }

       
            ViewBag.title = "Edit";
            return View("EditZone", zone);
        }

        // POST: Zone/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zone/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Zone/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

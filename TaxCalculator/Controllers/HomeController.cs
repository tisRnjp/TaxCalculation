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
    public class HomeController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();
        
        public ActionResult Index(int? citizenId)
        {


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var citizens = db.Citizens.ToList();
            Citizen citizen = db.Citizens.Find(id);
            if (citizen == null)
            {
                return HttpNotFound();
            }
            return View(citizen);
        }
    }
}
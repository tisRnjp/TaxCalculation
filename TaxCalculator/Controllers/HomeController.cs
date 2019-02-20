using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaxCalculator.DAL;
using TaxCalculator.Models;
using TaxCalculator.ViewModels;

namespace TaxCalculator.Controllers
{
    public class HomeController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();
        
        

        public ActionResult Index(string Search_Data)
        {
            var citizens = db.Citizens.ToList();
            if (Search_Data != null)
            {
                citizens = db.Citizens
                               .Where(c => c.FirstName.Contains(Search_Data) | c.LastName.Contains(Search_Data))
                               .ToList();
            }

           

            var citizenViewModel = new SearchCitizenViewModel {
                Citizens = citizens
            };
                
            return View(citizenViewModel);
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

        public ActionResult New()
        {
            var viewModel = new CitizenViewModel();
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CitizenViewModel viewModel)
        {
            db.Citizens.Add(viewModel.Citizen);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Edit(int? citizenID)
        {
            if (citizenID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var citizens = db.Citizens.ToList();
            Citizen citizen = db.Citizens.Find(citizenID);
            if (citizen == null)
            {
                return HttpNotFound();
            }
            return View(citizen);
        }

        public ActionResult Details(int? citizenID)
        {
            if (citizenID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var citizens = db.Citizens.ToList();
            Citizen citizen = db.Citizens.Find(citizenID);
            if (citizen == null)
            {
                return HttpNotFound();
            }
            return View(citizen);
        }

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var citizens = db.Citizens.ToList();
        //    Citizen citizen = db.Citizens.Find(id);
        //    if (citizen == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(citizen);
        //}
    }
}
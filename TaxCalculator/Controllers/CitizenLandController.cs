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
    [Authorize]
    public class CitizenLandController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();


        // GET: CitizenLand
        public ActionResult Index()
        {

            var lands = db.CitizenLands.ToList();
            //if (Search_Data != null)
            //{
            //    houses = db.Citizens
            //                   .Where(c => c.FirstName.Contains(Search_Data) | c.LastName.Contains(Search_Data))
            //                   .ToList();
            //}



            var landViewModel = new LandViewModel
            {
                CitizenLands = lands
            };

            return View(landViewModel);
            
        }

        public ActionResult New()
        {
            var citizens = db.Citizens.ToList();
            var viewModel = new LandFormViewModel
            {
                Citizens = citizens,
                CitizenLand = new CitizenLand()
            };

            ViewBag.title = "New Citizen Land";

            return View("CitizenLandForm", viewModel);
        }


        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var citizens = db.Citizens.ToList();
            var citizenLand = db.CitizenLands.Find(Id);

            if (citizenLand == null)
            {
                return HttpNotFound();
            }

            var viewModel = new LandFormViewModel
            {
                CitizenLand = citizenLand,
                Citizens = citizens
            };

            ViewBag.title = "Edit Land";

            return View("CitizenLandForm", viewModel);
        }


        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            CitizenLand citizenLand = db.CitizenLands.Find(Id);
            if (citizenLand == null)
            {
                return HttpNotFound();
            }

            var viewModel = new LandFormViewModel
            {
                CitizenLand = citizenLand,
                Citizens = db.Citizens.ToList()
            };

            //return View(citizen);
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(LandFormViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                var invalidViewModel = new LandFormViewModel
                {
                    CitizenLand = viewModel.CitizenLand,
                    Citizens = db.Citizens.ToList()
                };
                return View("CitizenLandForm", invalidViewModel);

            }


            if (viewModel.CitizenLand.Id == 0)
            {
                db.CitizenLands.Add(viewModel.CitizenLand);
            }
            else
            {
                var citizenLandInDB = db.CitizenLands.Single(c => c.Id == viewModel.CitizenLand.Id);
                citizenLandInDB.VDC = viewModel.CitizenLand.VDC;
                citizenLandInDB.WardNo = viewModel.CitizenLand.WardNo;
                citizenLandInDB.SheetNo = viewModel.CitizenLand.SheetNo;
                citizenLandInDB.KittaNo = viewModel.CitizenLand.KittaNo   ;
                citizenLandInDB.ValuationArea    = viewModel.CitizenLand.ValuationArea;
                citizenLandInDB.CitizenId = viewModel.CitizenLand.CitizenId;
            }

            db.SaveChanges();
            return RedirectToAction("Index", "CitizenLand");
        }



    }
}
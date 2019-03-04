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
    public class CitizenHouseController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();


        // GET: CitizenHouse
        public ActionResult Index()
        {

            var houses = db.CitizenHouses.ToList();
            //if (Search_Data != null)
            //{
            //    houses = db.Citizens
            //                   .Where(c => c.FirstName.Contains(Search_Data) | c.LastName.Contains(Search_Data))
            //                   .ToList();
            //}



            var houseViewModel = new HouseViewModel
            {
                CitizenHouses = houses
            };

            return View(houseViewModel);
            
        }

        public ActionResult New()
        {
            var citizens = db.Citizens.ToList();
            var viewModel = new HouseFormViewModel
            {
                Citizens = citizens,
                CitizenHouse = new CitizenHouse()
            };

            ViewBag.title = "New Citizen House";

            return View("CitizenHouseForm", viewModel);
        }


        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var citizens = db.Citizens.ToList();
            var citizenHouse = db.CitizenHouses.Find(Id);

            if (citizenHouse == null)
            {
                return HttpNotFound();
            }

            var viewModel = new HouseFormViewModel
            {
                CitizenHouse = citizenHouse,
                Citizens = citizens
            };

            ViewBag.title = "Edit";

            return View("CitizenHouseForm", viewModel);
        }


        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            CitizenHouse citizenHouse = db.CitizenHouses.Find(Id);
            if (citizenHouse == null)
            {
                return HttpNotFound();
            }

            var viewModel = new HouseFormViewModel
            {
                CitizenHouse = citizenHouse,
                Citizens = db.Citizens.ToList()
            };

            //return View(citizen);
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(HouseFormViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                var invalidViewModel = new HouseFormViewModel
                {
                    CitizenHouse = viewModel.CitizenHouse,
                    Citizens = db.Citizens.ToList()
                };
                return View("CitizenHouseForm", invalidViewModel);

            }


            if (viewModel.CitizenHouse.Id == 0)
            {
                db.CitizenHouses.Add(viewModel.CitizenHouse);
            }
            else
            {
                var citizenHouseInDB = db.CitizenHouses.Single(c => c.Id == viewModel.CitizenHouse.Id);
                citizenHouseInDB.Length = viewModel.CitizenHouse.Length;
                citizenHouseInDB.Width = viewModel.CitizenHouse.Width;
                citizenHouseInDB.Area = viewModel.CitizenHouse.Area;
                citizenHouseInDB.Floor = viewModel.CitizenHouse.Floor   ;
                citizenHouseInDB.CitizenId = viewModel.CitizenHouse.CitizenId;
            }

            db.SaveChanges();
            return RedirectToAction("Index", "CitizenHouse");
        }



    }
}
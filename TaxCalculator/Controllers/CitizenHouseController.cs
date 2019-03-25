using System;
using System.Collections.Generic;
using System.Drawing;
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
            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            if (viewModel.CitizenHouse.ImageUpload == null || viewModel.CitizenHouse.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!imageTypes.Contains(viewModel.CitizenHouse.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            //if (!ModelState.IsValid)
            //{
            //    var invalidViewModel = new HouseFormViewModel
            //    {
            //        CitizenHouse = viewModel.CitizenHouse,
            //        Citizens = db.Citizens.ToList()
            //    };
            //    return View("CitizenHouseForm", invalidViewModel);

            //}


            if (viewModel.CitizenHouse.Id == 0)
            {
                //// Save image to folder and get path
                //var imageName = String.Format("{0:yyyyMMdd-HHmmssfff}", DateTime.Now);
                //var extension = System.IO.Path.GetExtension(viewModel.CitizenHouse.ImageUpload.FileName).ToLower();
                //using (var img = System.Drawing.Image.FromStream(viewModel.CitizenHouse.ImageUpload.InputStream))
                //{
                //    viewModel.CitizenHouse.Image = String.Format("/CitizenHouseImages/{0}{1}", imageName, extension);
                //    //product.Thumb = String.Format("/ProductImages/{0}_thumb{1}", imageName, extension);

                //    //// Save thumbnail size image, 100 x 100
                //    //SaveToFolder(img, extension, new Size(100, 100), product.Thumb);

                //    // Save large size image, 600 x 600
                //    SaveToFolder(img, extension, new Size(600, 600), viewModel.CitizenHouse.Image);
                //}

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
       
        private void SaveToFolder(Image img, string extension, Size newSize, string pathToSave)
        {
            //// Get new resolution
            //Size imgSize = NewImageSize(img.Size, newSize);
            //using (System.Drawing.Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
            using (System.Drawing.Image newImg = new Bitmap(img, newSize.Width, newSize.Height))
            {
                newImg.Save(Server.MapPath(pathToSave), img.RawFormat);
            }
        }


    }
}
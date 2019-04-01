using Microsoft.Reporting.WebForms;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.UI.WebControls;
using TaxCalculator.DAL;
using TaxCalculator.Models;
using TaxCalculator.ViewModels;
using System.Data.Entity.Validation;
using System;

namespace TaxCalculator.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();
        
        

        public ActionResult Index(string Search_Data)
        {
            var citizens = db.Citizens.Include(z => z.Zone).ToList();
            //var citizens = db.Citizens.Include();
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
            var zones = db.Zones.ToList();
            var viewModel = new CitizenViewModel
            {
                Zones = zones,
                Citizen = new Citizen()

            };

            ViewBag.title = "New";

            return View("CitizenForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CitizenViewModel viewModel) 
        {

            //if (!ModelState.IsValid)
            //{
            //    var invalidViewModel = new CitizenViewModel
            //    {
            //        Citizen = viewModel.Citizen,
            //        Zones = db.Zones.ToList()
            //    };
            //    return View("CitizenForm",invalidViewModel);

            //}


            if (viewModel.Citizen.CitizenId == 0)
            {
                db.Citizens.Add(viewModel.Citizen);
                db.SaveChanges();
            }
            else
            {
                var citizenInDB = db.Citizens.Single(c => c.CitizenId == viewModel.Citizen.CitizenId);
                citizenInDB.FirstName = viewModel.Citizen.FirstName;
                citizenInDB.LastName = viewModel.Citizen.LastName;
                citizenInDB.StreetName = viewModel.Citizen.StreetName;
                citizenInDB.District = viewModel.Citizen.District;
                citizenInDB.ZoneId = viewModel.Citizen.ZoneId;
                citizenInDB.Wardno = viewModel.Citizen.Wardno;
                citizenInDB.CitizenshipNo = viewModel.Citizen.CitizenshipNo;
                citizenInDB.Municipality = viewModel.Citizen.Municipality;
                citizenInDB.KittaNo = viewModel.Citizen.KittaNo;

                db.SaveChanges();
            }


            if (viewModel.CitizenHouse.Id == 0)
            {
                viewModel.CitizenHouse.CitizenId = viewModel.Citizen.CitizenId;
                db.CitizenHouses.Add(viewModel.CitizenHouse);
                
                db.SaveChanges();
            }
            else
            {
                

                var citizenHouseInDB = db.CitizenHouses.Single(c => c.Id == viewModel.CitizenHouse.Id);
                citizenHouseInDB.Length = viewModel.CitizenHouse.Length;
                citizenHouseInDB.Width = viewModel.CitizenHouse.Width;
                citizenHouseInDB.Area = viewModel.CitizenHouse.Area;
                citizenHouseInDB.Floor = viewModel.CitizenHouse.Floor;
                citizenHouseInDB.CitizenId = viewModel.Citizen.CitizenId;
                db.SaveChanges();
              
            }

            if (viewModel.CitizenLand.Id == 0)
            {
                viewModel.CitizenLand.CitizenId = viewModel.Citizen.CitizenId;
                db.CitizenLands.Add(viewModel.CitizenLand);
                db.SaveChanges();
            }
            else
            {
                var citizenLandInDB = db.CitizenLands.Single(c => c.Id == viewModel.CitizenLand.Id);
                citizenLandInDB.VDC = viewModel.CitizenLand.VDC;
                citizenLandInDB.WardNo = viewModel.CitizenLand.WardNo;
                citizenLandInDB.SheetNo = viewModel.CitizenLand.SheetNo;
                citizenLandInDB.KittaNo = viewModel.CitizenLand.KittaNo;
                citizenLandInDB.ValuationArea = viewModel.CitizenLand.ValuationArea;
                citizenLandInDB.CitizenId = viewModel.Citizen.CitizenId;
                db.SaveChanges();

            }

            //try
            //{
                
            //}
            //catch(DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}
            
            return RedirectToAction("Index","Home");
        }

        public ActionResult Edit(int? citizenID)
        {
            if (citizenID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var citizens = db.Citizens.ToList();
            var citizen = db.Citizens.Find(citizenID);
            var citizenHouse = db.CitizenHouses.FirstOrDefault(c => c.CitizenId == citizenID);
            var citizenLand = db.CitizenLands.FirstOrDefault(c => c.CitizenId == citizenID);

            if (citizen == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CitizenViewModel
            {
                Citizen = citizen,
                Zones = db.Zones.ToList(),
                CitizenHouse = citizenHouse,
                CitizenLand = citizenLand
            };

            ViewBag.title = "Edit";
          
            return View("CitizenForm",viewModel);
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

            var viewModel = new CitizenViewModel
            {
                Citizen = citizen,
                Zones = db.Zones.ToList()
            };


            return View(viewModel);
        }

        public ActionResult CitizensReportViewer()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);

            reportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/CustomerList.rdlc");
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = db.Citizens.ToList();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            ViewBag.ReportViewer = reportViewer;
            return View();            

        }

        

        public ActionResult RajanKoReport(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/CitizenList.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "CitizenOnly";
            reportDataSource.Value = db.Citizens.ToList();
            localReport.DataSources.Add(reportDataSource);
            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension;
            if (ReportType == "Excel")
            {
                fileNameExtension = "xlsx";
            }
            else if (ReportType == "PDF")
            {
                fileNameExtension = "pdf";
            }
            else
            {
                fileNameExtension = "docx";
            }
            string[] streams;
            Warning[] warnings;
            byte[] renderByte;
            renderByte = localReport.Render(reportType, "", out mimeType, out encoding,
                                    out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment:filename= citizen_report." + fileNameExtension);
            return File(renderByte, fileNameExtension);

            //return View();
        }


        public ActionResult Reports(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/CustomerList.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = db.Citizens.ToList();
            localReport.DataSources.Add(reportDataSource);
            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension;
            if (ReportType == "Excel")
            {
                fileNameExtension = "xlsx";
            }
            else if (ReportType == "PDF")
            {
                fileNameExtension = "pdf";
            }
            else
            {
                fileNameExtension = "docx";
            }
            string[] streams;
            Warning[] warnings;
            byte[] renderByte;
            renderByte = localReport.Render(reportType, "", out mimeType, out encoding,
                                    out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment:filename= citizen_report." + fileNameExtension);
            return File(renderByte, fileNameExtension);

            //return View();
        }


        public ActionResult TaxReport(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/TaxReport.rdlc");

            //ReportDataSource reportDataSource = new ReportDataSource();
            //reportDataSource.Name = "DataSet1";
            //reportDataSource.Value = db.Citizens.ToList();
            //localReport.DataSources.Add(reportDataSource);

            localReport.DataSources.Add(new ReportDataSource {
                Name = "HouseTax",
                Value = db.HouseTaxHistories.Where(h => h.Id == 2).ToList()
                                                });
            localReport.DataSources.Add(new ReportDataSource { Name = "LandTax", Value = db.LandTaxHistories.Where(l => l.Id == 1).ToList() });
            localReport.DataSources.Add(new ReportDataSource { Name = "Citizen", Value = db.Citizens.ToList() });
            localReport.DataSources.Add(new ReportDataSource { Name = "Lands", Value = db.CitizenLands.Where(l => l.CitizenId == 2).ToList() });
            localReport.DataSources.Add(new ReportDataSource { Name = "houses", Value = db.CitizenHouses.Where(l => l.CitizenId == 2).ToList() });



            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension;

            if (ReportType == "Excel")
            {
                fileNameExtension = "xlsx";
            }
            else if (ReportType == "PDF")
            {
                fileNameExtension = "pdf";
            }
            else
            {
                fileNameExtension = "docx";
            }
            string[] streams;
            Warning[] warnings;
            byte[] renderByte;
            renderByte = localReport.Render(reportType, "", out mimeType, out encoding,
                                    out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment:filename= TaxReport." + fileNameExtension);
            return File(renderByte, fileNameExtension);

            //return View();
        }
       
        public ActionResult _CitizenDetails(int? citizenID)
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

            var viewModel = new CitizenViewModel
            {
                Citizen = citizen
            };
            return PartialView(viewModel);
        }
    }
}
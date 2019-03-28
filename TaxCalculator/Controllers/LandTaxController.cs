using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TaxCalculator.DAL;
using TaxCalculator.Models;
using TaxCalculator.ViewModels;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace TaxCalculator.Controllers
{
    [Authorize]
    public class LandTaxController : Controller
    {

        private CitizenDbContext db = new CitizenDbContext();
        // GET: LandTax
        public ActionResult Index()
        {
            var landTaxHistories = db.LandTaxHistories.Include(c => c.CitizenLand).ToList();
            var landTaxViewModel = new LandTaxViewModel
            {
                LandTaxHistories = landTaxHistories
            };

            return View(landTaxViewModel.LandTaxHistories);
        }

     

        public ActionResult LandTax(int? CitizenId)
        {

            var citizenLand = db.CitizenLands.First(c => c.CitizenId == CitizenId);
            var landTaxViewModel = new LandTaxViewModel();
            if (citizenLand != null)
            {
                landTaxViewModel.CitizenLand = db.CitizenLands.First(c => c.CitizenId == CitizenId);
                landTaxViewModel.FiscalYears = db.FiscalYears.ToList();
                landTaxViewModel.LandTaxHistory = new LandTaxHistory
                {
                    CitizenId = CitizenId,
                    ValuationArea = citizenLand.ValuationArea,
                    CitizenLandId = citizenLand.Id
                };
                landTaxViewModel.CitizenLands = db.CitizenLands.ToList();
                landTaxViewModel.Citizens = db.Citizens.ToList();
                landTaxViewModel.LandValuations = db.LandValuations.ToList();
            }
            return View("LandTaxCalculationForm",landTaxViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(LandTaxViewModel viewModel)
        {

            //if (!ModelState.IsValid)
            //{
            //    var invalidViewModel = new LandTaxViewModel
            //    {
            //        LandTaxHistory = viewModel.LandTaxHistory, 
            //    };
            //    return View("LandTaxCalculationForm", invalidViewModel);

            //}
        //     [Display(Name = "चारकिल्ला प्रमाणित गरिएको बारे")]
        //public HttpPostedFileBase File { get; set; }
        //[Display(Name = "घर बाटो खुलाई पठाएको बारे")]
        //public HttpPostedFileBase File1 { get; set; }
        //[Display(Name = "नाता प्रमाण")]
        //public HttpPostedFileBase File2 { get; set; }
        //[Display(Name = "विवाह प्रमाण")]
        //public HttpPostedFileBase File3 { get; set; }

            if (viewModel.LandTaxHistory.Id == 0)
            {
                db.LandTaxHistories.Add(viewModel.LandTaxHistory);
                db.SaveChanges();

                var fileName = "CharKilla-" + viewModel.LandTaxHistory.Id + "-KittaNo-" + viewModel.CitizenLand.KittaNo + Path.GetExtension(viewModel.File.FileName);// Path.GetFileName(viewModel.File.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                viewModel.File.SaveAs(path);

                fileName = "RoadOpening-" + viewModel.LandTaxHistory.Id + "-KittaNo-" + viewModel.CitizenLand.KittaNo + Path.GetExtension(viewModel.File1.FileName);// Path.GetFileName(viewModel.File.FileName);
                path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                viewModel.File.SaveAs(path);

                fileName = "RelationshipCertificate-" + viewModel.LandTaxHistory.Id + "-KittaNo-" + viewModel.CitizenLand.KittaNo + Path.GetExtension(viewModel.File2.FileName);// Path.GetFileName(viewModel.File.FileName);
                path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                viewModel.File.SaveAs(path);

                fileName = "MarriageCertificate-" + viewModel.LandTaxHistory.Id + "-KittaNo-" + viewModel.CitizenLand.KittaNo + Path.GetExtension(viewModel.File3.FileName);// Path.GetFileName(viewModel.File.FileName);
                path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                viewModel.File.SaveAs(path);

            }
            


            string ReportType = "pdf";

            LocalReport localReport = new LocalReport();
            if (!(viewModel.LandTaxHistory.FromFiscalYearId == viewModel.LandTaxHistory.ToFiscalYearId))
            {
                localReport.ReportPath = Server.MapPath("~/Reports/TaxReportMultiYear.rdlc");

                localReport.DataSources.Add(new ReportDataSource
                {
                    Name = "HouseTax",
                    Value = db.HouseTaxHistories.Where(h => h.Id == viewModel.LandTaxHistory.HouseTaxHistoryId).ToList()
                });
                localReport.DataSources.Add(new ReportDataSource { Name = "LandTax", Value = db.LandTaxHistories.Where(l => l.Id == viewModel.LandTaxHistory.Id).ToList() });
                localReport.DataSources.Add(new ReportDataSource { Name = "Citizen", Value = db.Citizens.Where(c => c.CitizenId == viewModel.LandTaxHistory.CitizenId).ToList() });
                localReport.DataSources.Add(new ReportDataSource { Name = "Lands", Value = db.CitizenLands.Where(l => l.CitizenId == viewModel.LandTaxHistory.CitizenId).ToList() });
                localReport.DataSources.Add(new ReportDataSource { Name = "houses", Value = db.CitizenHouses.Where(l => l.CitizenId == viewModel.LandTaxHistory.CitizenId).ToList() });


            }
            else
            {
                localReport.ReportPath = Server.MapPath("~/Reports/TaxReport.rdlc");

                localReport.DataSources.Add(new ReportDataSource
                {
                    Name = "HouseTax",
                    Value = db.HouseTaxHistories.Where(h => h.Id == viewModel.LandTaxHistory.HouseTaxHistoryId).ToList()
                });
                localReport.DataSources.Add(new ReportDataSource { Name = "LandTax", Value = db.LandTaxHistories.Where(l => l.Id == viewModel.LandTaxHistory.Id).ToList() });
                localReport.DataSources.Add(new ReportDataSource { Name = "Citizen", Value = db.Citizens.Where(c => c.CitizenId == viewModel.LandTaxHistory.CitizenId).ToList() });
                localReport.DataSources.Add(new ReportDataSource { Name = "Lands", Value = db.CitizenLands.Where(l => l.CitizenId == viewModel.LandTaxHistory.CitizenId).ToList() });
                localReport.DataSources.Add(new ReportDataSource { Name = "houses", Value = db.CitizenHouses.Where(l => l.CitizenId == viewModel.LandTaxHistory.CitizenId).ToList() });
            }


            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension;

            //if (ReportType == "Excel")
            //{
            //    fileNameExtension = "xlsx";
            //}
            //else if (ReportType == "PDF")
            //{
            //    fileNameExtension = "pdf";
            //}
            //else
            //{
            //    fileNameExtension = "docx";
            //}
            string[] streams;
            Warning[] warnings;
            byte[] renderByte;
            renderByte = localReport.Render(reportType, "", out mimeType, out encoding,
                                    out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment:filename= TaxReport." + fileNameExtension);
            //Writing to File
            var reportName = "LandTaxHistory-" + viewModel.LandTaxHistory.Id + "KittaNo-TaxReport"  + viewModel.CitizenLand.KittaNo + "." +  fileNameExtension;// Path.GetFileName(viewModel.File.FileName);
            var reportPath = Path.Combine(Server.MapPath("~/App_Data"), reportName);
           
            using (FileStream fileStream = System.IO.File.Create(reportPath, renderByte.Length))
            {
                fileStream.Write(renderByte, 0, renderByte.Length);
            }

            return File(renderByte, fileNameExtension);

            //return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaxReport(LandTaxViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var invalidViewModel = new LandTaxViewModel
                {
                    LandTaxHistory = viewModel.LandTaxHistory,
                };
                return View("LandTaxCalculationForm", invalidViewModel);

            }


            if (viewModel.LandTaxHistory.Id == 0)
            {
                db.LandTaxHistories.Add(viewModel.LandTaxHistory);
            }
            db.SaveChanges();


            string ReportType = "pdf";

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/TaxReport.rdlc");

            localReport.DataSources.Add(new ReportDataSource
            {
                Name = "HouseTax",
                Value = db.HouseTaxHistories.Where(h => h.Id == viewModel.LandTaxHistory.HouseTaxHistoryId).ToList()
            });
            localReport.DataSources.Add(new ReportDataSource { Name = "LandTax", Value = db.LandTaxHistories.Where(l => l.Id == viewModel.LandTaxHistory.Id).ToList() });
            localReport.DataSources.Add(new ReportDataSource { Name = "Citizen", Value = db.Citizens.Where(c => c.CitizenId == viewModel.LandTaxHistory.CitizenId).ToList() });
            localReport.DataSources.Add(new ReportDataSource { Name = "Lands", Value = db.CitizenLands.Where(l => l.CitizenId == viewModel.LandTaxHistory.CitizenId).ToList() });
            localReport.DataSources.Add(new ReportDataSource { Name = "houses", Value = db.CitizenHouses.Where(l => l.CitizenId == viewModel.LandTaxHistory.CitizenId).ToList() });


            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension;

            //if (ReportType == "Excel")
            //{
            //    fileNameExtension = "xlsx";
            //}
            //else if (ReportType == "PDF")
            //{
            //    fileNameExtension = "pdf";
            //}
            //else
            //{
            //    fileNameExtension = "docx";
            //}
            string[] streams;
            Warning[] warnings;
            byte[] renderByte;
            renderByte = localReport.Render(reportType, "", out mimeType, out encoding,
                                    out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment:filename= TaxReport." + fileNameExtension);
            return File(renderByte, fileNameExtension);

            //return View();
        }

        public ActionResult GetLandValuation(string category)
        {
            if (!string.IsNullOrWhiteSpace(category) && category.Length == 1)
            {
                var landValuation = db.LandValuations.Single(m => m.LandType == category);

                return Json(landValuation, JsonRequestBehavior.AllowGet);
            }
            return null;
        }




    }
}
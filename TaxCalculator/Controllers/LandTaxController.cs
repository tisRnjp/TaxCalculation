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

namespace TaxCalculator.Controllers
{
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

            return View(landTaxViewModel);
        }

     

        public ActionResult LandTax(int? CitizenId)
        {

            var citizenLand = db.CitizenLands.First(c => c.CitizenId == CitizenId);
            var landTaxViewModel = new LandTaxViewModel
            {
                
                CitizenLand = db.CitizenLands.First(c => c.CitizenId == CitizenId),
                LandTaxHistory = new LandTaxHistory { CitizenId = CitizenId,
                                    ValuationArea = citizenLand.ValuationArea,
                                    CitizenLandId = citizenLand.Id},
                CitizenLands = db.CitizenLands.ToList(),
                Citizens = db.Citizens.ToList()

            };
            
            return View("LandTaxCalculationForm",landTaxViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(LandTaxViewModel viewModel)
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

            //return RedirectToAction("Index", "LandTax");
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
    }
}
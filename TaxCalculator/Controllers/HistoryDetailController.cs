using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TaxCalculator.DAL;
using TaxCalculator.Models;
using TaxCalculator.ViewModels;

namespace TaxCalculator.Controllers
{
    public class HistoryDetailController : Controller
    {
        private CitizenDbContext db = new CitizenDbContext();
        // GET: HistoryDetail
        public ActionResult HistoryDetail(int? citizenID)
        {
            var citizen = db.Citizens.FirstOrDefault(c => c.CitizenId == citizenID);
            var houseTaxHistory = new HouseTaxHistory();
            var citizenHouse = new CitizenHouse();
            var nextFY = new FiscalYear();
            var landTaxHistory = db.LandTaxHistories
                                    .OrderByDescending(h => h.Id)
                                    .FirstOrDefault(h => h.CitizenId == citizenID);
            if (landTaxHistory != null)
            {
                
                houseTaxHistory = db.HouseTaxHistories
                                    .OrderByDescending(h => h.Id)
                                    .FirstOrDefault(h => h.Id == landTaxHistory.HouseTaxHistoryId);
                citizenHouse = db.CitizenHouses
                                    .OrderByDescending(h => h.Id)
                                    .FirstOrDefault(h => h.Id == houseTaxHistory.CitizenHouseId);
                nextFY = db.FiscalYears.Find(houseTaxHistory.ToFiscalYearId + 1);
            }
            else
            {
                landTaxHistory = new LandTaxHistory { CitizenId = citizenID,KittaNo = citizen.KittaNo};
            }
          
          
            
            var viewModel = new HistoryDetailViewModel
            {
                //Citizen = citizen,
                //Zones = db.Zones.ToList(),
                CitizenHouse = citizenHouse,
                LandTaxHistory = landTaxHistory,
                HouseTaxHistory = houseTaxHistory
            };
            if (landTaxHistory.Id == 0)
            {
                nextFY.FY = "75/76";
            }
            ViewBag.NextDueFY = nextFY.FY ;
            
            ViewBag.CurrentFY = "75/76";

            ViewBag.KittaNo = landTaxHistory.KittaNo;
            if ((landTaxHistory.ToFY == "75/76"))
            {
                  
                ViewBag.TaxNotification = " कित्ता न: " + landTaxHistory.KittaNo + " को आर्थिक वर्ष "+ nextFY.FY + " को कर तिर्न बाकी रहेको छ";
            }
            else
            {
                ViewBag.TaxNotification = "कित्ता न: " + landTaxHistory.KittaNo + " को आर्थिक वर्ष " + nextFY.FY + " देखि आर्थिक वर्ष 75/76 सम्मको कर तिर्न बाकी रहेको छ";
            } 
            
            
            return View(viewModel);
        }

        public ActionResult HistoryReport(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var history = db.LandTaxHistories.FirstOrDefault(l => l.CitizenId == Id);

            if (history == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(1000);
            reportViewer.Height = Unit.Percentage(900);
            reportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/TaxHistory.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportViewer.ShowPrintButton = true;

            var taxHistory = db.TaxHistories.Where(t => t.CitizenId == Id);

            var citizenHouse = db.CitizenHouses.FirstOrDefault(h => h.CitizenId == Id);
            var landTaxHistories = db.LandTaxHistories.Where(l => l.CitizenId == Id);
            var houseTaxHisories = db.HouseTaxHistories.Where(h => h.CitizenHouseId == citizenHouse.Id);
            var citizen = db.Citizens.Where(c => c.CitizenId == Id);
            
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource { Name = "LandTax", Value = landTaxHistories.ToList() });
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource { Name = "HouseTax", Value = houseTaxHisories.ToList() });
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource { Name = "Citizen", Value = citizen.ToList() });
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource { Name = "Citizen", Value = citizen.ToList() });
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource { Name = "TaxHistoryDataset", Value = taxHistory.ToList() });
            ViewBag.ReportViewer = reportViewer;
            return View("ReportViewer");
        }
    }
}

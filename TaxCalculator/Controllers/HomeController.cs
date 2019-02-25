using Microsoft.Reporting.WebForms;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.UI.WebControls;
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

            if (!ModelState.IsValid)
            {
                var invalidViewModel = new CitizenViewModel
                {
                    Citizen = viewModel.Citizen,
                    Zones = db.Zones.ToList()
                };
                return View("CitizenForm",invalidViewModel);

            }


            if (viewModel.Citizen.CitizenId == 0)
            {
                db.Citizens.Add(viewModel.Citizen);
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

            }
            
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
            var citizen = db.Citizens.Find(citizenID);

            if (citizen == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CitizenViewModel
            {
                Citizen = citizen,
                Zones = db.Zones.ToList()
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

            //return View(citizen);
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
            localReport.DataSources.Add(new ReportDataSource { Name = "LandTax", Value = db.LandTaxHistories.ToList() });
            localReport.DataSources.Add(new ReportDataSource { Name = "Citizen", Value = db.Citizens.ToList() });
            localReport.DataSources.Add(new ReportDataSource { Name = "Lands", Value = db.CitizenLands.Where(l => l.CitizenId == 2).ToList() });


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
       
    }
}
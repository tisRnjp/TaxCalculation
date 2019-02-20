using Microsoft.Reporting.WebForms;
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
            
            return View("CitizenForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(CitizenViewModel viewModel) 
        {

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
                citizenInDB.Zone = viewModel.Citizen.Zone;
                citizenInDB.Wardno = viewModel.Citizen.Wardno;
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
                Citizen = citizen
            };

          
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
            return View(citizen);
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
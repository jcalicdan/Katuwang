using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;

using CrystalDecisions.CrystalReports.Engine;

using System.IO;
using Microsoft.AspNetCore.Hosting;

using Katuwang.Data;
using Katuwang.Models;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using AspNetCoreHero.ToastNotification.Abstractions;


namespace Katuwang.Controllers
{
    public class ReportController : Controller
    {

        private readonly KatuwangContext _db;
        private IWebHostEnvironment Environment;
        public INotyfService _notifyService { get; }

        public ReportController(KatuwangContext db, IWebHostEnvironment _environment, INotyfService notyfService)
        {
            _db = db;
            Environment = _environment;
            _notifyService = notyfService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Masterlist()
        {
            List<Masterlist> allMasterlist = new List<Masterlist>();
            allMasterlist = _db.Masterlist.ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(this.Environment.WebRootPath, "reports", "Masterlist" + ".rpt"));

            rd.SetDataSource(allMasterlist);

            Response.StatusCode = 201;
            Response.StartAsync();
            Response.Headers.Clear();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Masterlist"+".pdf");
        }
    }
}

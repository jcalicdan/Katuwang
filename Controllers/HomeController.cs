using Katuwang.Data;
using Katuwang.Models;
using Katuwang.Models.StoredProcedure;
using Katuwang.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Katuwang.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly KatuwangSPContext _db;
        public INotyfService _notifyService { get; }

        public HomeController(KatuwangSPContext db, INotyfService notyfService)
        {
            _db = db;
            _notifyService = notyfService;
        }

        //public async Task<List<Dashboard>> Index()
        //{
        //    DataSet ds = new DataSet();

        //    return await _db.Dashboard.FromSqlRaw("EXEC sp_Dashboard_SerialNumber", ParallelMergeOptions.FullyBuffered).ToListAsync();
        //}

        public async Task<IActionResult> Index()
        {
            IEnumerable<Masterlist> objList = _db.Masterlist.Where(x => x.isdeleted == 0 & x.isactive == 1 & x.organization != "HDB").OrderBy( x => x.purok ).ThenBy(x => x.grupo);

            var result = await GetDashboad();
            
            foreach (var d in result)
            {
                ViewData[d.name] = d.value;
            }
            var addressDirectories = _db.AddressDirectory.FromSqlRaw("EXEC sp_Dashboard_AddressDirectory").ToList();

            var viewModel = new DashboardVM()
            {
                iMasterlist = objList,
                iAddressDirectory = addressDirectories
            };

            return await Task.Run(() => View(viewModel));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<List<Dashboard>> GetDashboad()
        {
            var SerailNumber = await _db.Dashboard.FromSqlRaw("EXEC sp_Dashboard_SerialNumber").ToListAsync();


            //var sambahayan = _db.Dashboard.FromSqlRaw("EXEC sp_Dashboard_Sambahayan").ToList();
            //var filteredJson = JsonConvert.SerializeObject(sambahayan);
            //ViewBag.Sambahayan = filteredJson;

            return SerailNumber.ToList();
        }

        public async Task<List<Dashboard>> GetSambahayan()
        {
            return await _db.Dashboard.FromSqlRaw("EXEC sp_Dashboard_Sambahayan").ToListAsync();
        }

        public async Task<List<Masterlist>> GetBirthdayCelebrants(int? id)
        {
            return await _db.Masterlist.FromSqlRaw("EXEC sp_Dashboard_BirthdayCelebrants "+ id).ToListAsync();
        }

    }
}

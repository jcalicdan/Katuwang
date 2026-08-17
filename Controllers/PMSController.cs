using Katuwang.Data;
using Katuwang.Models;
using Katuwang.Models.ViewModel;
using Katuwang.Models.JoinModel;
using Katuwang.Models.StoredProcedure;
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
    public class PMSController : Controller
    {
        private readonly KatuwangContext _db;
        public INotyfService _notifyService { get; }

        public PMSController(KatuwangContext db, INotyfService notyfService)
        {
            _db = db;
            _notifyService = notyfService;
        }

        public IActionResult Index()
        {
            var r401 = _db.R401.Where(x => x.status == "PMS" & x.isdeleted == 0);

            var cyear = _db.SystemParameter.Where(x => x.isdeleted == 0 & x.code == "CYEAR").Select(x => x.value).First();
            var cmonth = _db.SystemParameter.Where(x => x.isdeleted == 0 & x.code == "CMONV").Select(x => x.value).First();

            var masterlist = _db.Masterlist.Where(x => 1 == 1);

            var objList = _db.R401.Where(x => x.status == "PMS" & x.isdeleted == 0 & x.year == Convert.ToInt32(cyear) & x.month == cmonth.ToString())
                        .Join(_db.Masterlist, x => x.masterlistid, y => y.entryid,
                            ((r401, masterlist) => new R401Masterlist { R401 = r401, Masterlist = masterlist }))
                        .ToList();

            return View(objList);
        }

        public IActionResult Select()
        {
            IEnumerable<Masterlist> objList = _db.Masterlist.Where(x => x.isactive == 1 & x.isdeleted == 0);

            return View(objList);
        }

        // GET-Create
        public IActionResult Create(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Masterlist.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            MasterlistVM masterlistVM = new MasterlistVM()
            {
                Masterlist = obj,
                iDestinado = _db.Destinado.Where(x => x.isactive == 1 & x.isdeleted == 0),
                R401 = new R401()
            };

            return View(masterlistVM);
        }


        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MasterlistVM obj)
        {
            _db.R401.Add(obj.R401);
            _db.SaveChanges();

            return RedirectToAction("Select");
        }

        // GET-View
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj1 = _db.R401.Find(id);
            var obj2 = _db.Masterlist.Find(obj1.masterlistid);
            if (obj1 == null)
            {
                return NotFound();
            }

            MasterlistVM masterlistVM = new MasterlistVM()
            {
                R401 = obj1,
                iDestinado = _db.Destinado.Where(x => x.isactive == 1 & x.isdeleted == 0),
                Masterlist = obj2
            };

            return View(masterlistVM);
        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(MasterlistVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.R401.Update(obj.R401);
                _db.SaveChanges();

                var r401 = _db.R401.Where(x => x.status == "PMS" & x.isdeleted == 0);

                var masterlist = _db.Masterlist.Where(x => x.isdeleted == 0);

                var objList = _db.R401.Where(x => x.status == "PMS" & x.isdeleted == 0)
                            .Join(_db.Masterlist, x => x.masterlistid, y => y.entryid,
                                ((r401, masterlist) => new R401Masterlist { R401 = r401, Masterlist = masterlist }))
                            .ToList();

                return RedirectToAction("Index", objList);
            }

            return RedirectToAction("Select");

        }
        // GET-View
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj1 = _db.R401.Find(id);
            var obj2 = _db.Masterlist.Find(obj1.masterlistid);
            if (obj1 == null)
            {
                return NotFound();
            }

            MasterlistVM masterlistVM = new MasterlistVM()
            {
                R401 = obj1,
                iDestinado = _db.Destinado.Where(x => x.isactive == 1 & x.isdeleted == 0),
                Masterlist = obj2
            };

            return View(masterlistVM);
        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(MasterlistVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.R401.Update(obj.R401);
                _db.SaveChanges();

                var r401 = _db.R401.Where(x => x.status == "PMS" & x.isdeleted == 0);

                var masterlist = _db.Masterlist.Where(x => x.isdeleted == 0);

                var objList = _db.R401.Where(x => x.status == "PMS" & x.isdeleted == 0)
                            .Join(_db.Masterlist, x => x.masterlistid, y => y.entryid,
                                ((r401, masterlist) => new R401Masterlist { R401 = r401, Masterlist = masterlist }))
                            .ToList();

                return RedirectToAction("Index", objList);
            }

            return RedirectToAction("Select");

        }

        public async Task<List<R401>> GetPreviousMonth(int? year, string month)
        {
            return await _db.R401.FromSqlRaw("EXEC sp_PMS_PreviousMonth {0}, {1}", year, month).ToListAsync();
        }
    }
}

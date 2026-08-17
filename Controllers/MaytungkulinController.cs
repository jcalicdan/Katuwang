using Katuwang.Data;
using Katuwang.Models;
using Katuwang.Models.ViewModel;
using Katuwang.Models.JoinModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Katuwang.Controllers
{
    public class MaytungkulinController : Controller
    {
        private readonly KatuwangContext _db;
        private IWebHostEnvironment Environment;
        public INotyfService _notifyService { get; }

        public MaytungkulinController(KatuwangContext db, IWebHostEnvironment _environment, INotyfService notyfService)
        {
            _db = db;
            Environment = _environment;
            _notifyService = notyfService;
        }

        public IActionResult Index()
        {
            var maytungkulin = _db.Maytungkulin.Where(x => x.isdeleted == 0);

            var masterlist = _db.Masterlist.Where(x => x.isdeleted == 0);

            var objList = _db.Maytungkulin.Where(x => x.isdeleted == 0)
                        .Join(_db.Masterlist, x => x.masterlistid, y => y.entryid,
                            ((maytungkulin, masterlist) => new MaytungkulinMasterlist { Maytungkulin = maytungkulin, Masterlist = masterlist }))
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
            var obj1 = _db.Masterlist.Find(id);
            var obj2 = _db.Maytungkulin.Find(obj1.entryid);
            if (obj1 == null)
            {
                return NotFound();
            }

            MasterlistVM masterlistVM = new MasterlistVM()
            {
                Maytungkulin = new Maytungkulin(),
                iMaytungkulin = _db.Maytungkulin.Where(x => x.masterlistid == obj1.entryid & x.isdeleted == 0),
                Masterlist = obj1
            };

            return View(masterlistVM);
        }


        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MasterlistVM obj)
        {
            _db.Maytungkulin.Add(obj.Maytungkulin);
            _db.SaveChanges();

            int entryid = _db.Maytungkulin.Max(x => x.entryid);
            _notifyService.Success("Entry ID " + entryid + " is created", 2);
            return RedirectToAction("Create", new { id = obj.Maytungkulin.masterlistid } );
        }

        // GET-View
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj1 = _db.Maytungkulin.Find(id);
            var obj2 = _db.Masterlist.Find(obj1.masterlistid);
            if (obj1 == null)
            {
                return NotFound();
            }

            MasterlistVM masterlistVM = new MasterlistVM()
            {
                Maytungkulin = obj1,
                iMaytungkulin = _db.Maytungkulin.Where(x => x.masterlistid == obj1.masterlistid & x.isdeleted == 0),
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
                _db.Maytungkulin.Update(obj.Maytungkulin);
                _db.SaveChanges();

                var maytungkulin = _db.Maytungkulin.Where(x => x.isdeleted == 0);

                var masterlist = _db.Masterlist.Where(x => x.isdeleted == 0);

                var objList = _db.Maytungkulin.Where(x => x.isdeleted == 0)
                            .Join(_db.Masterlist, x => x.masterlistid, y => y.entryid,
                                ((maytungkulin, masterlist) => new MaytungkulinMasterlist { Maytungkulin = maytungkulin, Masterlist = masterlist }))
                            .ToList();

                _notifyService.Success("Entry ID " + obj.Maytungkulin.entryid + " is updated", 2);
                return RedirectToAction("Create", new { id = obj.Maytungkulin.masterlistid } );
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
            var obj1 = _db.Maytungkulin.Find(id);
            var obj2 = _db.Masterlist.Find(obj1.masterlistid);
            if (obj1 == null)
            {
                return NotFound();
            }

            MasterlistVM masterlistVM = new MasterlistVM()
            {
                Maytungkulin = obj1,
                iMaytungkulin = _db.Maytungkulin.Where(x => x.masterlistid == obj1.masterlistid & x.isdeleted == 0),
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
                _db.Maytungkulin.Update(obj.Maytungkulin);
                _db.SaveChanges();

                var maytungkulin = _db.Maytungkulin.Where(x => x.isdeleted == 0);

                var masterlist = _db.Masterlist.Where(x => x.isdeleted == 0);

                var objList = _db.Maytungkulin.Where(x => x.isdeleted == 0)
                            .Join(_db.Masterlist, x => x.masterlistid, y => y.entryid,
                                ((maytungkulin, masterlist) => new MaytungkulinMasterlist { Maytungkulin = maytungkulin, Masterlist = masterlist }))
                            .ToList();

                _notifyService.Error("Entry ID " + obj.Maytungkulin.entryid + " is deleted", 2);
                return RedirectToAction("Create", new { id = obj.Maytungkulin.masterlistid });
            }

            return RedirectToAction("Select");

        }

        // POST UPDATE
        public async Task<IActionResult> OrasNgPanata(int entryId, bool isChecked)
        {
            var person = await _db.Maytungkulin.FindAsync(entryId);
            if (person != null)
            {
                var isupdated = isChecked ? "1" : "0";

                person.remarks1 = isupdated;
                _db.Maytungkulin.Update(person);
                await _db.SaveChangesAsync();
                _notifyService.Success("Entry ID " + person.entryid.ToString() + " remarks1 is updated", 2);
                return Ok();
            }
            return NotFound();
        }

        // POST UPDATE
        public async Task<IActionResult> UpdateIsUpdated(int entryId, bool isChecked)
        {
            var person = await _db.Maytungkulin.FindAsync(entryId);
            if (person != null)
            {
                var isupdated = isChecked ? "1" : "0";

                person.remarks2 = isupdated;
                _db.Maytungkulin.Update(person);
                await _db.SaveChangesAsync();
                _notifyService.Success("Entry ID " + person.entryid.ToString() + " remarks2 is updated", 2);
                return Ok();
            }
            return NotFound();
        }
    }
}

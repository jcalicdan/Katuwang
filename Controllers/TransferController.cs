using Katuwang.Data;
using Katuwang.Models;
using Katuwang.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Katuwang.Controllers
{
    [Authorize]
    public class TransferController : Controller
    {
        private readonly KatuwangContext _db;
        public INotyfService _notifyService { get; }

        public TransferController(KatuwangContext db, INotyfService notyfService)
        {
            _db = db;
            _notifyService = notyfService;
        }

        public IActionResult Index()
        {
            IEnumerable<Masterlist> objList = _db.Masterlist.Where(x => x.isactive != 1);

            return View(objList);
        }

        public IActionResult IN_Index()
        {
            IEnumerable<Masterlist> objList = _db.Masterlist.Where(x => x.isactive != 1);
            
            return View(objList);
        }

        public IActionResult OUT_Index()
        {
            IEnumerable<Masterlist> objList = _db.Masterlist.Where(x => x.isactive != 0);

            return View(objList);
        }

        // GET-Create
        public IActionResult IN_Create(int? id)
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

            MasterlistVM MasterlistVM = new MasterlistVM()
            {
                Masterlist = obj,
                Transfer = new Transfer()
            };

            return View(MasterlistVM);
        }

        // GET-Create
        public IActionResult OUT_Create(int? id)
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

            MasterlistVM MasterlistVM = new MasterlistVM()
            {
                Masterlist = obj,
                Transfer = new Transfer()
            };

            return View(MasterlistVM);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IN_Create(MasterlistVM obj)
        {
            _db.Transfer.Add(obj.Transfer);
            _db.SaveChanges();
            _db.Update(obj.Masterlist);
            _db.SaveChanges();
            return RedirectToAction("Index", "Masterlist");
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OUT_Create(MasterlistVM obj)
        {
            _db.Transfer.Add(obj.Transfer);
            _db.SaveChanges();
            _db.Update(obj.Masterlist);
            _db.SaveChanges();
            return RedirectToAction("OUT_Index");
        }

    }
}

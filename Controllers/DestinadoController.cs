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
    public class DestinadoController : Controller
    {
        private readonly KatuwangContext _db;
        public INotyfService _notifyService { get; }

        public DestinadoController(KatuwangContext db, INotyfService notyfService)
        {
            _db = db;
            _notifyService = notyfService;
        }

        public IActionResult Index()
        {
            var objList = _db.Destinado;

            return View(objList);
        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }


        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Destinado obj)
        {
            _db.Destinado.Add(obj);
            _db.SaveChanges();

            _notifyService.Success(obj.givenname.ToString() + " is created", 2);
            return RedirectToAction("Create");
        }

        // GET-View
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Destinado.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Destinado obj)
        {
            if (ModelState.IsValid)
            {
                _db.Destinado.Update(obj);
                _db.SaveChanges();

                _notifyService.Success(obj.givenname.ToString() + " is updated", 2);

                return View(obj);
            }
            return RedirectToAction("Index");
        }


        // GET-View
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Destinado.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Destinado obj)
        {
            if (ModelState.IsValid)
            {
                _db.Destinado.Update(obj);
                _db.SaveChanges();

                var person = _db.Masterlist.Find(obj.entryid);
                _notifyService.Success(person.givenname.ToString() + " is deleted", 2);
                return RedirectToAction("Create", new { id = obj.entryid });
            }
            return RedirectToAction("Index");

        }
    }
}

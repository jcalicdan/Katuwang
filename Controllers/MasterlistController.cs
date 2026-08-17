using Katuwang.Data;
using Katuwang.Models;
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
    [Authorize]
    public class MasterlistController : Controller
    {
        private readonly KatuwangContext _db;
        private IWebHostEnvironment Environment;
        public INotyfService _notifyService { get; }

        public MasterlistController(KatuwangContext db, IWebHostEnvironment _environment, INotyfService notyfService)
        {
            _db = db;
            Environment = _environment;
            _notifyService = notyfService;
        }

        public IActionResult Index()
        {
            IEnumerable<Masterlist> objList = _db.Masterlist.Where(x => x.isdeleted == 0);
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
        public IActionResult Create(Masterlist obj)
        {
            _db.Masterlist.Add(obj);
            _db.SaveChanges();
            int entryid = _db.Masterlist.Max(x => x.entryid);

            var person = _db.Masterlist.Find(entryid);
            _notifyService.Success(person.givenname.ToString() + " is created", 2);
            return RedirectToAction("IN_Create", "Transfer", new { id = obj.entryid });
            //return RedirectToAction("Create", new { id = entryid , Controllers = "Transfer"});
        }

        // GET-View
        public IActionResult View(int? id)
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
            return View(obj);

        }

        // GET-View
        public IActionResult Update(int? id)
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
            return View(obj);
        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Masterlist obj)
        {
            if (ModelState.IsValid)
            {
                _db.Masterlist.Update(obj);
                _db.SaveChanges();

                IEnumerable<Masterlist> objList = _db.Masterlist.Where(x => x.isdeleted == 0);
                var person = _db.Masterlist.Find(obj.entryid);
                _notifyService.Success(person.givenname.ToString() + " is updated", 2);
                return RedirectToAction("Index", objList);
            }
            return View(obj);

        }

        // GET-View
        public IActionResult Delete(int? id)
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
            return View(obj);
        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Masterlist obj)
        {
            if (ModelState.IsValid)
            {
                _db.Masterlist.Update(obj);
                _db.SaveChanges();
                _notifyService.Success("Record is deleted successfuly", 2);
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        public IActionResult UploadImage(int entryid)
        {
            ViewBag.EntryId = entryid;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(int? entryid)
        {
            string base64 = Request.Form["imgCropped"];
            byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);

            string filePath = Path.Combine(this.Environment.WebRootPath, "images", entryid.ToString() + ".png");
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
            }
            var person = _db.Masterlist.Find(entryid);
            _notifyService.Success(person.givenname.ToString() + " is updated", 2);
            return RedirectToAction("Update", new { id = entryid });
        }

        // POST UPDATE
        public async Task<IActionResult> UpdateIsUpdated(int entryId, bool isChecked)
        {
            var person = await _db.Masterlist.FindAsync(entryId);
            if (person != null)
            {
                var isupdated = isChecked ? 1 : 0;

                person.isupdated = isupdated;
                _db.Masterlist.Update(person);
                await _db.SaveChangesAsync();
                _notifyService.Success(person.givenname.ToString() + " is updated", 2);
                return Ok();
            }
            return NotFound();
        }


        public IActionResult Sambahayan()
        {
            IEnumerable<Masterlist> objList = _db.Masterlist.Where(x => x.isdeleted == 0 & x.isactive == 1)
                .OrderBy(x => x.purok)
                .ThenBy(x => x.grupo)
                .ThenBy(x => x.sambahayan)
                .ThenBy(x => x.fathersname);
            return View(objList);
        }

        // POST UPDATE
        public async Task<IActionResult> UpdateRelasyon(int entryId, string relasyon, int sambahayan)
        {
            var person = await _db.Masterlist.FindAsync(entryId);
            if (person != null)
            {
                person.sambahayan = sambahayan;
                person.relasyon = relasyon;
                _db.Masterlist.Update(person);
                await _db.SaveChangesAsync();
                _notifyService.Success(person.givenname.ToString() + " is updated", 2);
                return Ok();
            }
            return NotFound();
        }
    }
}

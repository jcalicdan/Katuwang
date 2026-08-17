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
    public class SystemParameterController : Controller
    {
        private readonly KatuwangContext _db;
        public INotyfService _notifyService { get; }

        public SystemParameterController(KatuwangContext db, INotyfService notyfService)
        {
            _db = db;
            _notifyService = notyfService;
        }

        public IActionResult Index()
        {
            var objList = _db.SystemParameter.Where(x => x.isdeleted == 0);
            return View(objList);
        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }


        // POST-Create
        public IActionResult Create(SystemParameter obj)
        {
            _db.SystemParameter.Add(obj);
            _db.SaveChanges();

            _notifyService.Success(obj.name.ToString() + " is created", 2);

            return RedirectToAction("Index");
        }

        // GET-View
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.SystemParameter.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST UPDATE
        public async Task<IActionResult> UpdateValue(int entryId, string value)
        {
            var item = await _db.SystemParameter.FindAsync(entryId);
            if (item != null)
            {
                item.value = value;
                _db.SystemParameter.Update(item);
                await _db.SaveChangesAsync();
                _notifyService.Success(item.name.ToString() + " is updated", 2);
                return Ok();
            }
            return NotFound();
        }

        // POST UPDATE
        public async Task<IActionResult> UpdateIsUpdated(int entryId, bool isChecked)
        {
            var item = await _db.SystemParameter.FindAsync(entryId);
            if (item != null)
            {
                var isupdated = isChecked ? 1 : 0;

                item.isdeleted = isupdated;
                _db.SystemParameter.Update(item);
                await _db.SaveChangesAsync();
                _notifyService.Success(item.name.ToString() + " is updated", 2);
                return Ok();
            }
            return NotFound();
        }
    }
}

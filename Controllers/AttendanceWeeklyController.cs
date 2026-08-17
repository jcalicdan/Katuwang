using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katuwang.Controllers
{
    public class AttendanceWeeklyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

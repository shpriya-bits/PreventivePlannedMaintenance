﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PreventivePlannedMaintenance.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard_Index()
        {
            return View();
        }
    }
}
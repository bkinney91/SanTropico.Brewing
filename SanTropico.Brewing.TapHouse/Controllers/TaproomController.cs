﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SanTropico.Brewing.TapHouse.Controllers
{
    public class TaproomController : Controller
    {
        public IActionResult OnTap()
        {
            return View();
        }
    }
}
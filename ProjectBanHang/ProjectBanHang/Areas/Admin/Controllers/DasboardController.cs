﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class DasboardController : Controller
    {
        // GET: Admin/Dasboard
        public ActionResult Index()
        {
            return View();
        }
    }
}
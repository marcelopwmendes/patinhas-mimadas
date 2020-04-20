﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatinhasMimadas.Web.Models;

namespace PatinhasMimadas.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View("List");
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult Add(EmployeeViewModel model)
        {
            return View();
        }

    }
}
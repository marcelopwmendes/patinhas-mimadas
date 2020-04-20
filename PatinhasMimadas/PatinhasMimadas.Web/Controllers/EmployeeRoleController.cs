using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PatinhasMimadas.Web.Controllers
{
    public class EmployeeRoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
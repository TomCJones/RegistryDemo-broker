using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistryDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
    }
}

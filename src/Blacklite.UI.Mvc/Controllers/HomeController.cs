using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Blacklite.UI.Mvc.Controllers
{
    public class HomeModel
    {
        [Required]
        public string Name { get; set; }
    }

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeModel()
            {
                Name = "My Name"
            });
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
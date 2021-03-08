using SQLProgrammability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLProgrammability.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //SQLPro db = new SQLPro();
            //db.ProFunction.Count();

            return View();
        }
    }
}

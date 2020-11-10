using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PringleAPI.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Get()
        {
            return View();
        }
        public ActionResult Post()
        {
            return View();
        }
        public ActionResult Put()
        {
            return View();
        }
        public ActionResult Patch()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}

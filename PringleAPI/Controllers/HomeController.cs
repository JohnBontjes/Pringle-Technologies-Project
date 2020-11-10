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
            ViewBag.Action = "Home";

            return View();
        }
        public ActionResult Get()
        {
            ViewBag.Action = "Get";
            return View();
        }
        public ActionResult Post()
        {
            ViewBag.Action = "Post";
            return View();
        }
        public ActionResult Put()
        {
            ViewBag.Action = "Put";
            return View();
        }
        public ActionResult Patch()
        {
            ViewBag.Action = "Patch";
            return View();
        }
        public ActionResult Delete()
        {
            ViewBag.Action = "Delete";
            return View();
        }
    }
}

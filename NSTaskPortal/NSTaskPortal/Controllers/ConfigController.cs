using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace NSTaskPortal.Controllers
{
    public class ConfigController : Controller
    {
        // GET: Config
        public ActionResult Index()
        {
            return View();
        }

        // GET: Config/Edit/5
        [HttpGet]
        public ActionResult Edit()
        {
            ViewBag.NSUserName = WebConfigurationManager.AppSettings["NSUserName"];
            ViewBag.NSPassword = WebConfigurationManager.AppSettings["NSPassword"];
            ViewBag.TSECount = WebConfigurationManager.AppSettings["TSECount"];
            ViewBag.TSEPerDay = WebConfigurationManager.AppSettings["TSEPerDay"];
            return View();
        }

        // POST: Config/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            WebConfigurationManager.AppSettings.Set("NSUserName", collection.Get("NSUserName"));
            WebConfigurationManager.AppSettings.Set("NSPassword", collection.Get("NSPassword"));
            WebConfigurationManager.AppSettings.Set("TSECount", collection.Get("TSECount"));
            WebConfigurationManager.AppSettings.Set("TSEPerDay", collection.Get("TSEPerDay"));
            TempData["saved"] = true;
            return RedirectToAction("Edit");
        }
    }
}
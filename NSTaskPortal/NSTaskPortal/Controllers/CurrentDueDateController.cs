using NSTaskPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NSTaskPortal.Controllers
{
    public class CurrentDueDateController : Controller
    {
        private NSTaskPortalContext db = new NSTaskPortalContext();

        // GET: CurrentDueDate
        public ActionResult CurrentDueDate()
        {
            double taskHours = 0;

            foreach (NSTask task in db.NSTasks.ToList())
            {
                taskHours += task.Hours;
            }

            ViewData["hours"] = taskHours;

            return View();
        }

        public void PopulateDummyData()
        {
            NSQueue q = new NSQueue();
            //q.Add(new NSSupportTask("Upgrade Prod", 1.5, "Corey", 144));
            //q.Add(new NSProjectTask("Install BAM", 4.0, "Kirk"));
        }
    }
}
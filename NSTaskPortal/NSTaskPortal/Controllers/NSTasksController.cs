using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NSTaskPortal.Models;

namespace NSTaskPortal.Controllers
{
    public class NSTasksController : Controller
    {
        private NSTaskPortalContext db = new NSTaskPortalContext();

        // GET: NSTasks
        public ActionResult Index()
        {
            return View(db.NSTasks.ToList());
        }

        // GET: NSTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTask nSTask = db.NSTasks.Find(id);
            if (nSTask == null)
            {
                return HttpNotFound();
            }
            return View(nSTask);
        }

        // GET: NSTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NSTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NSTaskID,Name,Hours,AssignedTo,TaskType")] NSTask nSTask)
        {
            if (ModelState.IsValid)
            {
                db.NSTasks.Add(nSTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nSTask);
        }

        // GET: NSTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTask nSTask = db.NSTasks.Find(id);
            if (nSTask == null)
            {
                return HttpNotFound();
            }
            return View(nSTask);
        }

        // POST: NSTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NSTaskID,Name,Hours,AssignedTo,TaskType")] NSTask nSTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nSTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nSTask);
        }

        // GET: NSTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTask nSTask = db.NSTasks.Find(id);
            if (nSTask == null)
            {
                return HttpNotFound();
            }
            return View(nSTask);
        }

        // POST: NSTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NSTask nSTask = db.NSTasks.Find(id);
            db.NSTasks.Remove(nSTask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

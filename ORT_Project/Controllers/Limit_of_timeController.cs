using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ORT_Project.Models;

namespace ORT_Project.Controllers
{
    public class Limit_of_timeController : Controller
    {
        private ORTEntities db = new ORTEntities();

        // GET: Limit_of_time
        public ActionResult Index()
        {
            return View(db.Limit_of_time.ToList());
        }

        // GET: Limit_of_time/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Limit_of_time limit_of_time = db.Limit_of_time.Find(id);
            if (limit_of_time == null)
            {
                return HttpNotFound();
            }
            return View(limit_of_time);
        }

        // GET: Limit_of_time/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Limit_of_time/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Time,Date_of_limit,Limit_start,Limit_end")] Limit_of_time limit_of_time)
        {
            if (ModelState.IsValid)
            {
                db.Limit_of_time.Add(limit_of_time);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(limit_of_time);
        }

        // GET: Limit_of_time/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Limit_of_time limit_of_time = db.Limit_of_time.Find(id);
            if (limit_of_time == null)
            {
                return HttpNotFound();
            }
            return View(limit_of_time);
        }

        // POST: Limit_of_time/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Time,Date_of_limit,Limit_start,Limit_end")] Limit_of_time limit_of_time)
        {
            if (ModelState.IsValid)
            {
                db.Entry(limit_of_time).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(limit_of_time);
        }

        // GET: Limit_of_time/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Limit_of_time limit_of_time = db.Limit_of_time.Find(id);
            if (limit_of_time == null)
            {
                return HttpNotFound();
            }
            return View(limit_of_time);
        }

        // POST: Limit_of_time/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Limit_of_time limit_of_time = db.Limit_of_time.Find(id);
            db.Limit_of_time.Remove(limit_of_time);
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

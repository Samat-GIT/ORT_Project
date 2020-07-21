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
    public class Fired_EmployeeController : Controller
    {
        private ORTEntities db = new ORTEntities();

        // GET: Fired_Employee
        public ActionResult Index()
        {
            var fired_Employee = db.Fired_Employee.Include(f => f.Employees);
            return View(fired_Employee.ToList());
        }

        // GET: Fired_Employee/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fired_Employee fired_Employee = db.Fired_Employee.Find(id);
            if (fired_Employee == null)
            {
                return HttpNotFound();
            }
            return View(fired_Employee);
        }

        // GET: Fired_Employee/Create
        public ActionResult Create()
        {
            ViewBag.ID_Employee = new SelectList(db.Employees, "ID_Employee", "Surname");
            return View();
        }

        // POST: Fired_Employee/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_fired,Date_leavingFierd,Date_appointmentFired,ID_Employee")] Fired_Employee fired_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Fired_Employee.Add(fired_Employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Employee = new SelectList(db.Employees, "ID_Employee", "Surname", fired_Employee.ID_Employee);
            return View(fired_Employee);
        }

        // GET: Fired_Employee/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fired_Employee fired_Employee = db.Fired_Employee.Find(id);
            if (fired_Employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Employee = new SelectList(db.Employees, "ID_Employee", "Surname", fired_Employee.ID_Employee);
            return View(fired_Employee);
        }

        // POST: Fired_Employee/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_fired,Date_leavingFierd,Date_appointmentFired,ID_Employee")] Fired_Employee fired_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fired_Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Employee = new SelectList(db.Employees, "ID_Employee", "Surname", fired_Employee.ID_Employee);
            return View(fired_Employee);
        }

        // GET: Fired_Employee/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fired_Employee fired_Employee = db.Fired_Employee.Find(id);
            if (fired_Employee == null)
            {
                return HttpNotFound();
            }
            return View(fired_Employee);
        }

        // POST: Fired_Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Fired_Employee fired_Employee = db.Fired_Employee.Find(id);
            db.Fired_Employee.Remove(fired_Employee);
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

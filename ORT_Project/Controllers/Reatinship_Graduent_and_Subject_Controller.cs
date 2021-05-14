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
    public class Reatinship_Graduent_and_Subject_Controller : Controller
    {
        private ORTEntities db = new ORTEntities();

        // GET: Reatinship_Graduent_and_Subject_
        public ActionResult Index()
        {
            var reatinship_Graduent_and_Subject_ = db.Reatinship_Graduent_and_Subject_.Include(r => r.Graduant).Include(r => r.Subject);
            return View(reatinship_Graduent_and_Subject_.ToList());
        }

        // GET: Reatinship_Graduent_and_Subject_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reatinship_Graduent_and_Subject_ reatinship_Graduent_and_Subject_ = db.Reatinship_Graduent_and_Subject_.Find(id);
            if (reatinship_Graduent_and_Subject_ == null)
            {
                return HttpNotFound();
            }
            return View(reatinship_Graduent_and_Subject_);
        }

        // GET: Reatinship_Graduent_and_Subject_/Create
        public ActionResult Create()
        {
            ViewBag.ID_Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name");
            ViewBag.ID_Subject = new SelectList(db.Subject, "ID_Subject", "Subject_name");
            return View();
        }

        // POST: Reatinship_Graduent_and_Subject_/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Reationship,ID_Graduent,ID_Subject")] Reatinship_Graduent_and_Subject_ reatinship_Graduent_and_Subject_)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Reatinship_Graduent_and_Subject_.Add(reatinship_Graduent_and_Subject_);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.message = "Абитуриент уже зарегистрирован на данную дисциплину!";
                    ViewBag.ID_Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name", reatinship_Graduent_and_Subject_.ID_Graduent);
                    ViewBag.ID_Subject = new SelectList(db.Subject, "ID_Subject", "Subject_name", reatinship_Graduent_and_Subject_.ID_Subject);
                    return View(reatinship_Graduent_and_Subject_);
                }
            }

            ViewBag.ID_Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name", reatinship_Graduent_and_Subject_.ID_Graduent);
            ViewBag.ID_Subject = new SelectList(db.Subject, "ID_Subject", "Subject_name", reatinship_Graduent_and_Subject_.ID_Subject);
            return View(reatinship_Graduent_and_Subject_);
        }

        // GET: Reatinship_Graduent_and_Subject_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reatinship_Graduent_and_Subject_ reatinship_Graduent_and_Subject_ = db.Reatinship_Graduent_and_Subject_.Find(id);
            if (reatinship_Graduent_and_Subject_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name", reatinship_Graduent_and_Subject_.ID_Graduent);
            ViewBag.ID_Subject = new SelectList(db.Subject, "ID_Subject", "Subject_name", reatinship_Graduent_and_Subject_.ID_Subject);
            return View(reatinship_Graduent_and_Subject_);
        }

        // POST: Reatinship_Graduent_and_Subject_/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Reationship,ID_Graduent,ID_Subject")] Reatinship_Graduent_and_Subject_ reatinship_Graduent_and_Subject_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reatinship_Graduent_and_Subject_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name", reatinship_Graduent_and_Subject_.ID_Graduent);
            ViewBag.ID_Subject = new SelectList(db.Subject, "ID_Subject", "Subject_name", reatinship_Graduent_and_Subject_.ID_Subject);
            return View(reatinship_Graduent_and_Subject_);
        }

        // GET: Reatinship_Graduent_and_Subject_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reatinship_Graduent_and_Subject_ reatinship_Graduent_and_Subject_ = db.Reatinship_Graduent_and_Subject_.Find(id);
            if (reatinship_Graduent_and_Subject_ == null)
            {
                return HttpNotFound();
            }
            return View(reatinship_Graduent_and_Subject_);
        }

        // POST: Reatinship_Graduent_and_Subject_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reatinship_Graduent_and_Subject_ reatinship_Graduent_and_Subject_ = db.Reatinship_Graduent_and_Subject_.Find(id);
            db.Reatinship_Graduent_and_Subject_.Remove(reatinship_Graduent_and_Subject_);
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

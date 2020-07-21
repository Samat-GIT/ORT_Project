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
    public class Access_ticketController : Controller
    {
        private ORTEntities db = new ORTEntities();

        // GET: Access_ticket
        public ActionResult Index()
        {
            var access_ticket = db.Access_ticket.Include(a => a.Graduant);
            return View(access_ticket.ToList());
        }

        // GET: Access_ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_ticket access_ticket = db.Access_ticket.Find(id);
            if (access_ticket == null)
            {
                return HttpNotFound();
            }
            return View(access_ticket);
        }

        // GET: Access_ticket/Create
        public ActionResult Create()
        {
            ViewBag.Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name");
            return View();
        }

        // POST: Access_ticket/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ticet,Photo_3x4,Photo_signature,Photo_of_passport,Document_number,Notification,Document_selection,Graduent")] Access_ticket access_ticket)
        {
            if (ModelState.IsValid)
            {
                db.Access_ticket.Add(access_ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name", access_ticket.Graduent);
            return View(access_ticket);
        }

        // GET: Access_ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_ticket access_ticket = db.Access_ticket.Find(id);
            if (access_ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name", access_ticket.Graduent);
            return View(access_ticket);
        }

        // POST: Access_ticket/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ticet,Photo_3x4,Photo_signature,Photo_of_passport,Document_number,Notification,Document_selection,Graduent")] Access_ticket access_ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(access_ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name", access_ticket.Graduent);
            return View(access_ticket);
        }

        // GET: Access_ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_ticket access_ticket = db.Access_ticket.Find(id);
            if (access_ticket == null)
            {
                return HttpNotFound();
            }
            return View(access_ticket);
        }

        // POST: Access_ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Access_ticket access_ticket = db.Access_ticket.Find(id);
            db.Access_ticket.Remove(access_ticket);
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

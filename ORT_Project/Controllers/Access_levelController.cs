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
    public class Access_levelController : Controller
    {
        private ORTEntities db = new ORTEntities();

        // GET: Access_level
        public ActionResult Index()
        {
            return View(db.Access_level.ToList());
        }

        // GET: Access_level/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_level access_level = db.Access_level.Find(id);
            if (access_level == null)
            {
                return HttpNotFound();
            }
            return View(access_level);
        }

        // GET: Access_level/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Access_level/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_access_level,Access_level1")] Access_level access_level)
        {
            if (ModelState.IsValid)
            {
                db.Access_level.Add(access_level);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(access_level);
        }

        // GET: Access_level/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_level access_level = db.Access_level.Find(id);
            if (access_level == null)
            {
                return HttpNotFound();
            }
            return View(access_level);
        }

        // POST: Access_level/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_access_level,Access_level1")] Access_level access_level)
        {
            if (ModelState.IsValid)
            {
                db.Entry(access_level).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(access_level);
        }

        // GET: Access_level/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access_level access_level = db.Access_level.Find(id);
            if (access_level == null)
            {
                return HttpNotFound();
            }
            return View(access_level);
        }

        // POST: Access_level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Access_level access_level = db.Access_level.Find(id);
            db.Access_level.Remove(access_level);
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

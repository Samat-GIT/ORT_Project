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
    public class AuthorizationsController : Controller
    {
        private ORTEntities db = new ORTEntities();

        // GET: Authorizations
        public ActionResult Index()
        {
            return View(db.Authorization.ToList());
        }

        // GET: Authorizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Authorization authorization = db.Authorization.Find(id);
            if (authorization == null)
            {
                return HttpNotFound();
            }
            return View(authorization);
        }

        // GET: Authorizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authorizations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Autorization,Login,Password")] Models.Authorization authorization)
        {
            if (ModelState.IsValid)
            {
                db.Authorization.Add(authorization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorization);
        }

        // GET: Authorizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Authorization authorization = db.Authorization.Find(id);
            if (authorization == null)
            {
                return HttpNotFound();
            }
            return View(authorization);
        }

        // POST: Authorizations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Autorization,Login,Password")] Models.Authorization authorization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorization);
        }

        // GET: Authorizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Authorization authorization = db.Authorization.Find(id);
            if (authorization == null)
            {
                return HttpNotFound();
            }
            return View(authorization);
        }

        // POST: Authorizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Authorization authorization = db.Authorization.Find(id);
            db.Authorization.Remove(authorization);
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

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
    public class District_town_Controller : Controller
    {
        private ORTEntities db = new ORTEntities();

        // GET: District_town_
        public ActionResult Index(string SearchString, string sortOrder)
        {
            var district_town_ = db.District_town_.Include(d => d.Region1);
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RegSortParm = sortOrder == "Reg_asc" ? "Reg_desc" : "Reg_asc";
            switch (sortOrder)
            {
                case "name_desc":
                    district_town_ = district_town_.OrderByDescending(x => x.District_name);
                    break;
                case "Reg_desc":
                    district_town_ = district_town_.OrderByDescending(x => x.Region);
                    break;
            }
                   
            if (!String.IsNullOrEmpty(SearchString))
            {
                return View(district_town_.Where(x => x.District_name.Contains(SearchString)));
            }
            return View(district_town_.ToList());
        }

        // GET: District_town_/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District_town_ district_town_ = db.District_town_.Find(id);
            if (district_town_ == null)
            {
                return HttpNotFound();
            }
            return View(district_town_);
        }

        // GET: District_town_/Create
        public ActionResult Create()
        {
            ViewBag.Region = new SelectList(db.Region, "ID_Region", "Region_name");
            return View();
        }

        // POST: District_town_/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_District,District_name,Password_district,Region")] District_town_ district_town_)
        {
            if (ModelState.IsValid)
            {
                db.District_town_.Add(district_town_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Region = new SelectList(db.Region, "ID_Region", "Region_name", district_town_.Region);
            return View(district_town_);
        }

        // GET: District_town_/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District_town_ district_town_ = db.District_town_.Find(id);
            if (district_town_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.Region = new SelectList(db.Region, "ID_Region", "Region_name", district_town_.Region);
            return View(district_town_);
        }

        // POST: District_town_/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_District,District_name,Password_district,Region")] District_town_ district_town_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district_town_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Region = new SelectList(db.Region, "ID_Region", "Region_name", district_town_.Region);
            return View(district_town_);
        }

        // GET: District_town_/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District_town_ district_town_ = db.District_town_.Find(id);
            if (district_town_ == null)
            {
                return HttpNotFound();
            }
            return View(district_town_);
        }

        // POST: District_town_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            District_town_ district_town_ = db.District_town_.Find(id);
            db.District_town_.Remove(district_town_);
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

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
    public class SchoolsController : Controller
    {
        private ORTEntities db = new ORTEntities();

        // GET: Schools
        public ActionResult Index(string SearchString, string sortOrder)
        {
            var school = db.School.Include(s => s.District_town_);
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ZipSortParm = sortOrder == "ZIP_asc" ? "ZIP_desc" : "ZIP_asc";
            ViewBag.CodeSortParm = sortOrder == "Code_asc" ? "Code_desc" : "Code_asc";
            ViewBag.DistrictSortParm = String.IsNullOrEmpty(sortOrder) ? "district_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            switch (sortOrder)
            {
                case "name_desc":
                    school = school.OrderByDescending(x=>x.School_name);
                    break;
                case "ZIP_desc":
                    school = school.OrderByDescending(x => x.Postal_zip);
                    break;
                case "ZIP_asc":
                    school = school.OrderBy(x => x.Postal_zip);
                    break;
                case "Code_desc":
                    school = school.OrderByDescending(x => x.Code_of_school);
                    break;
                case "Code_asc":
                    school = school.OrderBy(x => x.Code_of_school);
                    break;
                case "district_desc":
                    school = school.OrderByDescending(x => x.District);
                    break;
            }
            
            if (!String.IsNullOrEmpty(SearchString))
            {
                school = school.Where(x => x.School_name.Contains(SearchString));
            }
            return View(school.ToList());
        }

        // GET: Schools/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.School.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // GET: Schools/Create
        public ActionResult Create()
        {
            ViewBag.District = new SelectList(db.District_town_, "ID_District", "District_name");
            return View();
        }

        // POST: Schools/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_School,School_name,Postal_zip,Code_of_school,Password_school,LocalitiName,LocalityAddress,District")] School school)
        {
            if (ModelState.IsValid)
            {
                db.School.Add(school);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.District = new SelectList(db.District_town_, "ID_District", "District_name", school.District);
            return View(school);
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.School.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            ViewBag.District = new SelectList(db.District_town_, "ID_District", "District_name", school.District);
            return View(school);
        }

        // POST: Schools/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_School,School_name,Postal_zip,Code_of_school,Password_school,LocalitiName,LocalityAddress,District")] School school)
        {
            if (ModelState.IsValid)
            {
                db.Entry(school).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.District = new SelectList(db.District_town_, "ID_District", "District_name", school.District);
            return View(school);
        }

        // GET: Schools/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.School.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            School school = db.School.Find(id);
            db.School.Remove(school);
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

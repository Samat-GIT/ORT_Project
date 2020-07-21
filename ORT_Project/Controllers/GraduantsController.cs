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
    public class GraduantsController : Controller
    {
        private ORTEntities db = new ORTEntities();

        // GET: Graduants
        public ActionResult Index()
        {
            var graduant = db.Graduant.Include(g => g.Authorization).Include(g => g.Category_Graduent).Include(g => g.District_town_).Include(g => g.Language1).Include(g => g.School1);
            return View(graduant.ToList());
        }

        // GET: Graduants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduant graduant = db.Graduant.Find(id);
            if (graduant == null)
            {
                return HttpNotFound();
            }
            return View(graduant);
        }

        // GET: Graduants/Create
        public ActionResult Create()
        {
            ViewBag.Authoriziation = new SelectList(db.Authorization, "id_Autorization", "Login");
            ViewBag.Category = new SelectList(db.Category_Graduent, "ID_Category", "Category_Graduent1");
            ViewBag.Distrit = new SelectList(db.District_town_, "ID_District", "District_name");
            ViewBag.Language = new SelectList(db.Language, "id_language", "Language_name");
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name");
            return View();
        }

        // POST: Graduants/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Graduant,Sur_name,First_name,Third_name,Birth_date,Gender,Street,Microdistrict,Apartment_House,Email,Phone_number,Diplom_number,Attestat_number,Date_of_registr,LocalityName,LocalityAddress,Category,Distrit,School,Language,Authoriziation")] Graduant graduant)
        {
            if (ModelState.IsValid)
            {
                db.Graduant.Add(graduant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Authoriziation = new SelectList(db.Authorization, "id_Autorization", "Login", graduant.Authoriziation);
            ViewBag.Category = new SelectList(db.Category_Graduent, "ID_Category", "Category_Graduent1", graduant.Category);
            ViewBag.Distrit = new SelectList(db.District_town_, "ID_District", "District_name", graduant.Distrit);
            ViewBag.Language = new SelectList(db.Language, "id_language", "Language_name", graduant.Language);
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name", graduant.School);
            return View(graduant);
        }

        // GET: Graduants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduant graduant = db.Graduant.Find(id);
            if (graduant == null)
            {
                return HttpNotFound();
            }
            ViewBag.Authoriziation = new SelectList(db.Authorization, "id_Autorization", "Login", graduant.Authoriziation);
            ViewBag.Category = new SelectList(db.Category_Graduent, "ID_Category", "Category_Graduent1", graduant.Category);
            ViewBag.Distrit = new SelectList(db.District_town_, "ID_District", "District_name", graduant.Distrit);
            ViewBag.Language = new SelectList(db.Language, "id_language", "Language_name", graduant.Language);
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name", graduant.School);
            return View(graduant);
        }

        // POST: Graduants/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Graduant,Sur_name,First_name,Third_name,Birth_date,Gender,Street,Microdistrict,Apartment_House,Email,Phone_number,Diplom_number,Attestat_number,Date_of_registr,LocalityName,LocalityAddress,Category,Distrit,School,Language,Authoriziation")] Graduant graduant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graduant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Authoriziation = new SelectList(db.Authorization, "id_Autorization", "Login", graduant.Authoriziation);
            ViewBag.Category = new SelectList(db.Category_Graduent, "ID_Category", "Category_Graduent1", graduant.Category);
            ViewBag.Distrit = new SelectList(db.District_town_, "ID_District", "District_name", graduant.Distrit);
            ViewBag.Language = new SelectList(db.Language, "id_language", "Language_name", graduant.Language);
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name", graduant.School);
            return View(graduant);
        }

        // GET: Graduants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduant graduant = db.Graduant.Find(id);
            if (graduant == null)
            {
                return HttpNotFound();
            }
            return View(graduant);
        }

        // POST: Graduants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Graduant graduant = db.Graduant.Find(id);
            db.Graduant.Remove(graduant);
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

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
    public class EmployeesController : Controller
    {
        private ORTEntities db = new ORTEntities();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Access_level1).Include(e => e.Authorization).Include(e => e.District_town_).Include(e => e.Position1).Include(e => e.School1);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.Access_level = new SelectList(db.Access_level, "ID_access_level", "Access_level1");
            ViewBag.Authotization = new SelectList(db.Authorization, "id_Autorization", "Login");
            ViewBag.District = new SelectList(db.District_town_, "ID_District", "District_name");
            ViewBag.Position = new SelectList(db.Position, "ID_Position", "Position_Name");
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name");
            return View();
        }

        // POST: Employees/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Employee,Surname,First_name,Third_Name,Birth_date,Gender,Phone_number,INN_passport,Address,Email,Date_of_appointment,Fired,Position,Access_level,District,School,Authotization")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Access_level = new SelectList(db.Access_level, "ID_access_level", "Access_level1", employees.Access_level);
            ViewBag.Authotization = new SelectList(db.Authorization, "id_Autorization", "Login", employees.Authotization);
            ViewBag.District = new SelectList(db.District_town_, "ID_District", "District_name", employees.District);
            ViewBag.Position = new SelectList(db.Position, "ID_Position", "Position_Name", employees.Position);
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name", employees.School);
            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            ViewBag.Access_level = new SelectList(db.Access_level, "ID_access_level", "Access_level1", employees.Access_level);
            ViewBag.Authotization = new SelectList(db.Authorization, "id_Autorization", "Login", employees.Authotization);
            ViewBag.District = new SelectList(db.District_town_, "ID_District", "District_name", employees.District);
            ViewBag.Position = new SelectList(db.Position, "ID_Position", "Position_Name", employees.Position);
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name", employees.School);
            return View(employees);
        }

        // POST: Employees/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Employee,Surname,First_name,Third_Name,Birth_date,Gender,Phone_number,INN_passport,Address,Email,Date_of_appointment,Fired,Position,Access_level,District,School,Authotization")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Access_level = new SelectList(db.Access_level, "ID_access_level", "Access_level1", employees.Access_level);
            ViewBag.Authotization = new SelectList(db.Authorization, "id_Autorization", "Login", employees.Authotization);
            ViewBag.District = new SelectList(db.District_town_, "ID_District", "District_name", employees.District);
            ViewBag.Position = new SelectList(db.Position, "ID_Position", "Position_Name", employees.Position);
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name", employees.School);
            return View(employees);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
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

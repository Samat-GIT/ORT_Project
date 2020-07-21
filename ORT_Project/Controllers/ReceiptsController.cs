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
    public class ReceiptsController : Controller
    {
        private ORTEntities db = new ORTEntities();

        // GET: Receipts
        public ActionResult Index()
        {
            var receipt = db.Receipt.Include(r => r.Employees).Include(r => r.Graduant).Include(r => r.School1);
            return View(receipt.ToList());
        }

        // GET: Receipts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // GET: Receipts/Create
        public ActionResult Create()
        {
            ViewBag.Head_of_teacher = new SelectList(db.Employees, "ID_Employee", "Surname");
            ViewBag.Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name");
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name");
            return View();
        }

        // POST: Receipts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Raceipt,Receipt_num,Receipt_sum,Payment_Date,Bank_branch_num,School,Head_of_teacher,Graduent")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Receipt.Add(receipt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Head_of_teacher = new SelectList(db.Employees, "ID_Employee", "Surname", receipt.Head_of_teacher);
            ViewBag.Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name", receipt.Graduent);
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name", receipt.School);
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.Head_of_teacher = new SelectList(db.Employees, "ID_Employee", "Surname", receipt.Head_of_teacher);
            ViewBag.Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name", receipt.Graduent);
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name", receipt.School);
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Raceipt,Receipt_num,Receipt_sum,Payment_Date,Bank_branch_num,School,Head_of_teacher,Graduent")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Head_of_teacher = new SelectList(db.Employees, "ID_Employee", "Surname", receipt.Head_of_teacher);
            ViewBag.Graduent = new SelectList(db.Graduant, "ID_Graduant", "Sur_name", receipt.Graduent);
            ViewBag.School = new SelectList(db.School, "ID_School", "School_name", receipt.School);
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receipt receipt = db.Receipt.Find(id);
            db.Receipt.Remove(receipt);
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

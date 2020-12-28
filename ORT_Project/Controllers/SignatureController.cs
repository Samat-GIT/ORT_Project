using ORT_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORT_Project.Controllers
{
    public class SignatureController : Controller
    {
        // GET: Signature
        public ActionResult Index()
        {
            using (ORTEntities db = new ORTEntities())
            {
                var graduant = db.SignaturesTable;
                return View(graduant.ToList());
            }
            
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ORT_Project.Models.SignaturesTable signatures)
        {
            string fileName = Path.GetFileNameWithoutExtension(signatures.ImageFile.FileName);
            string fileName1 = Path.GetFileNameWithoutExtension(signatures.ImageFileSign.FileName);
            string extension = Path.GetExtension(signatures.ImageFile.FileName);
            string extension1 = Path.GetExtension(signatures.ImageFileSign.FileName);
            fileName = fileName + DateTime.Now.ToString("yy.MM.HH") + extension;
            fileName1 = fileName1 + DateTime.Now.ToString("yy.MM.HH") + extension1;
            signatures.Photo3x4 = "~/Photos/" + fileName;
            signatures.PhotoSignature = "~/Photos/" + fileName1;
            
            fileName = Path.Combine(Server.MapPath("~/Photos/"),fileName);
            fileName1 = Path.Combine(Server.MapPath("~/Photos/"), fileName1);

            signatures.ImageFile.SaveAs(fileName);
            signatures.ImageFileSign.SaveAs(fileName1);

            using (ORTEntities db = new ORTEntities())
            {
                db.SignaturesTable.Add(signatures);
                db.SaveChanges();
            
            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult ShowView(int id)
        {
            SignaturesTable signaturesTable = new SignaturesTable();
            using(ORTEntities db = new ORTEntities())
            {
                signaturesTable = db.SignaturesTable.Where(x => x.ID == id).FirstOrDefault();
            }
            return View(signaturesTable);
        }
    }
}
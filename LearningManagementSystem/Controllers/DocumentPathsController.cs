using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearningManagementSystem.Models;

namespace LearningManagementSystem.Controllers
{
    public class DocumentPathsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DocumentPaths
        public ActionResult Index()
        {
            var documents = db.Documents.Include(d => d.User);
            return View(documents.ToList());
        }

        // GET: DocumentPaths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentPath documentPath = db.Documents.Find(id);
            if (documentPath == null)
            {
                return HttpNotFound();
            }
            return View(documentPath);
        }

        // GET: DocumentPaths/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: DocumentPaths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DocumentName,DocumentDescription,FilePath,UploadDate,GroupId,CourseId,ActivityId,UserId")] DocumentPath documentPath)
        {
            if (ModelState.IsValid)
            {
                db.Documents.Add(documentPath);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", documentPath.UserId);
            return View(documentPath);
        }

        // GET: DocumentPaths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentPath documentPath = db.Documents.Find(id);
            if (documentPath == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", documentPath.UserId);
            return View(documentPath);
        }

        // POST: DocumentPaths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DocumentName,DocumentDescription,FilePath,UploadDate,GroupId,CourseId,ActivityId,UserId")] DocumentPath documentPath)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentPath).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", documentPath.UserId);
            return View(documentPath);
        }

        // GET: DocumentPaths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentPath documentPath = db.Documents.Find(id);
            if (documentPath == null)
            {
                return HttpNotFound();
            }
            return View(documentPath);
        }

        // POST: DocumentPaths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentPath documentPath = db.Documents.Find(id);
            db.Documents.Remove(documentPath);
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

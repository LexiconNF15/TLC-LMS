using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearningManagementSystem.Models;
using System.IO;

namespace LearningManagementSystem.Controllers
{
    [Authorize(Roles="Teacher")]
    public class DocumentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //private const string localUrl = @"~\Uploads\" ;
        private const string localUrl = @"\Uploads\";

        // GET: Documents
        public ActionResult Index()
        {
            var documents = db.Documents.Include(d => d.Uploader);
            return View(documents.ToList());
        }

        // GET: Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        public ActionResult Create(int? GrId)
        {
            TempData["GroupId"] = GrId;
            ViewBag.UploaderId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentId,DocumentName,Description,FileName,FilePath,UploaderId,UploadDate,GroupId,CourseId,ActivityId")] Document document, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                 
                var CurrentUser = db.Users.Where(u => u.UserName == User.Identity.Name.ToString()).ToList().FirstOrDefault();
                if (CurrentUser.GroupId != null)
                {
                    document.GroupId = CurrentUser.GroupId;
                }
                else if (TempData["GroupId"] != null)
                {
                    document.GroupId = (int)TempData["GroupId"];
                }
                else
                {
                    document.GroupId = null;
                }

                if (upload != null && upload.ContentLength > 0)
                {
                    // Här sparas filen som ska laddas upp i vår katalog
                    string nameOfFile = System.IO.Path.GetFileName(upload.FileName);
                    string saveFilePath = Path.Combine((Server.MapPath(@"~\Uploads\")), nameOfFile);
                    upload.SaveAs(saveFilePath);

                    /// Här laddar vi dbset<Documents> med korrekta värden.
                    document.UploadDate = DateTime.Now;
                    document.FileName = nameOfFile;
                    document.FilePath = (@localUrl + nameOfFile);
                    document.UploaderId = CurrentUser.Id;
                    db.Documents.Add(document);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }

            ViewBag.UploaderId = new SelectList(db.Users, "Id", "FirstName", document.UploaderId, document.GroupId);
            return View(document);
        }


        // GET: Documents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UploaderId = new SelectList(db.Users, "Id", "FirstName", document.UploaderId);
            //Group group = db.Groups.Find(id);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentId,DocumentName,Description")] Document document)
        {
            if (ModelState.IsValid)
            {
                Document NewDocument = db.Documents.Find(document.DocumentId);
                NewDocument.DocumentName = document.DocumentName;
                NewDocument.Description = document.Description;

                db.Entry(NewDocument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UploaderId = new SelectList(db.Users, "Id", "FirstName", document.UploaderId);
            return View(document);
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Download(int? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);

            string path = Server.MapPath(document.FilePath);

            if (System.IO.File.Exists(path))
            {
                return File(path,
                MimeMapping.GetMimeMapping(document.FileName), document.FileName);
            }
            return HttpNotFound();
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

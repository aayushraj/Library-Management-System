using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Models;

namespace LibraryMS.Controllers
{
    public class BookController : Controller
    {
        private BookDbContext db = new BookDbContext();

        // GET: /Book/
        public ActionResult Index()
        {
            return View(db.Book.ToList());
        }

        // GET: /Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInfo bookinfo = db.Book.Find(id);
            if (bookinfo == null)
            {
                return HttpNotFound();
            }
            return View(bookinfo);
        }

        // GET: /Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BookId,BookName,Author,Edition,Price,Quantity,AddedDate,ModifiedDate,Availablity")] BookInfo bookinfo)
        {
            if (ModelState.IsValid)
            {
                db.Book.Add(bookinfo);
                bookinfo.AddedDate = DateTime.Now;
                //bookinfo.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookinfo);
        }

        // GET: /Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInfo bookinfo = db.Book.Find(id);
            if (bookinfo == null)
            {
                return HttpNotFound();
            }
            return View(bookinfo);
        }

        // POST: /Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BookId,BookName,Author,Edition,Price,Quantity,AddedDate,ModifiedDate,Availablity")] BookInfo bookinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookinfo).State = EntityState.Modified;
                //bookinfo.AddedDate = DateTime.Now;
                bookinfo.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookinfo);
        }

        // GET: /Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInfo bookinfo = db.Book.Find(id);
            if (bookinfo == null)
            {
                return HttpNotFound();
            }
            return View(bookinfo);
        }

        // POST: /Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookInfo bookinfo = db.Book.Find(id);
            db.Book.Remove(bookinfo);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemRezerwacji.DAL;
using SystemRezerwacji.Models;

namespace SystemRezerwacji.Controllers
{
    [Authorize(Users ="144070@stud.prz.edu.pl")]
    public class PodrozniController : Controller
    {
        private SystemRezerwacjiContext db = new SystemRezerwacjiContext();

        // GET: Podrozni
        public ActionResult Index()
        {
            return View(db.Podrozni.ToList());
        }

        // GET: Podrozni/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podrozny podrozny = db.Podrozni.Find(id);
            if (podrozny == null)
            {
                return HttpNotFound();
            }
            return View(podrozny);
        }

        // GET: Podrozni/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Podrozni/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwisko,Imie,Email")] Podrozny podrozny)
        {
            if (ModelState.IsValid)
            {
                db.Podrozni.Add(podrozny);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(podrozny);
        }

        // GET: Podrozni/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podrozny podrozny = db.Podrozni.Find(id);
            if (podrozny == null)
            {
                return HttpNotFound();
            }
            return View(podrozny);
        }

        // POST: Podrozni/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwisko,Imie,Email")] Podrozny podrozny)
        {
            if (ModelState.IsValid)
            {
                db.Entry(podrozny).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(podrozny);
        }

        // GET: Podrozni/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podrozny podrozny = db.Podrozni.Find(id);
            if (podrozny == null)
            {
                return HttpNotFound();
            }
            return View(podrozny);
        }

        // POST: Podrozni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Podrozny podrozny = db.Podrozni.Find(id);
            db.Podrozni.Remove(podrozny);
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

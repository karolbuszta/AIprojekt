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
    [Authorize(Users = "144070@stud.prz.edu.pl")]
    public class RezerwacjeController : Controller
    {
        private SystemRezerwacjiContext db = new SystemRezerwacjiContext();

        // GET: Rezerwacje
        public ActionResult Index()
        {
            return View(db.Rezerwacje.ToList());
        }

        // GET: Rezerwacje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacja rezerwacja = db.Rezerwacje.Find(id);
            if (rezerwacja == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacja);
        }

        // GET: Rezerwacje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rezerwacje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PolaczenieID,PodroznyID,StatusRezerwacjiId")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                db.Rezerwacje.Add(rezerwacja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rezerwacja);
        }

        // GET: Rezerwacje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacja rezerwacja = db.Rezerwacje.Find(id);
            if (rezerwacja == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacja);
        }

        // POST: Rezerwacje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PolaczenieID,PodroznyID,StatusRezerwacjiId")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezerwacja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezerwacja);
        }

        // GET: Rezerwacje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacja rezerwacja = db.Rezerwacje.Find(id);
            if (rezerwacja == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacja);
        }

        // POST: Rezerwacje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezerwacja rezerwacja = db.Rezerwacje.Find(id);
            db.Rezerwacje.Remove(rezerwacja);
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

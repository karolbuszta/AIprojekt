using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SystemRezerwacji.DAL;
using SystemRezerwacji.Models;

namespace SystemRezerwacji.Controllers
{
    public class PolaczeniaController : Controller
    {
        private SystemRezerwacjiContext db = new SystemRezerwacjiContext();

        // GET: Polaczenia
        public ActionResult Index()
        {
            var polaczenia = db.Polaczenia.Include(p => p.Relacje);
            return View(polaczenia.ToList());
        }

        // GET: Polaczenia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polaczenie polaczenie = db.Polaczenia.Find(id);
            if (polaczenie == null)
            {
                return HttpNotFound();
            }
            return View(polaczenie);
        }

        // GET: Polaczenia/Create
        [Authorize(Users = "144070@stud.prz.edu.pl")]
        public ActionResult Create()
        {
            ViewBag.RelacjaId = new SelectList(db.Relacje, "Id", "Id");
            return View();
        }

        // POST: Polaczenia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RelacjaId,Czas_odjazdu,Czas_przyjazdu,Kategoria,Cena")] Polaczenie polaczenie)
        {
            if (ModelState.IsValid)
            {
                db.Polaczenia.Add(polaczenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RelacjaId = new SelectList(db.Relacje, "Id", "Id", polaczenie.RelacjaId);
            return View(polaczenie);
        }

        // GET: Polaczenia/Edit/5
        [Authorize(Users = "144070@stud.prz.edu.pl")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polaczenie polaczenie = db.Polaczenia.Find(id);
            if (polaczenie == null)
            {
                return HttpNotFound();
            }
            ViewBag.RelacjaId = new SelectList(db.Relacje, "Id", "Id", polaczenie.RelacjaId);
            return View(polaczenie);
        }

        // POST: Polaczenia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RelacjaId,Czas_odjazdu,Czas_przyjazdu,Kategoria,Cena")] Polaczenie polaczenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(polaczenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RelacjaId = new SelectList(db.Relacje, "Id", "Id", polaczenie.RelacjaId);
            return View(polaczenie);
        }

        // GET: Polaczenia/Delete/5
        [Authorize(Users = "144070@stud.prz.edu.pl")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polaczenie polaczenie = db.Polaczenia.Find(id);
            if (polaczenie == null)
            {
                return HttpNotFound();
            }
            return View(polaczenie);
        }

        // POST: Polaczenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Polaczenie polaczenie = db.Polaczenia.Find(id);
            db.Polaczenia.Remove(polaczenie);
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

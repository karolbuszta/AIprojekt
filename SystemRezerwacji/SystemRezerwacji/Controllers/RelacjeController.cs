using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SystemRezerwacji.DAL;
using SystemRezerwacji.Models;

namespace SystemRezerwacji.Controllers
{
    public class RelacjeController : Controller
    {
        private SystemRezerwacjiContext db = new SystemRezerwacjiContext();

        // GET: Relacje
        public ActionResult Index()
        {
            return View(db.Relacje.ToList());
        }

        // GET: Relacje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relacja relacja = db.Relacje.Find(id);
            if (relacja == null)
            {
                return HttpNotFound();
            }
            return View(relacja);
        }

        // GET: Relacje/Create
        [Authorize(Users = "144070@stud.prz.edu.pl")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Relacje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Stacja_poczatkowa,Stacja_koncowa,Stacja_posrednia,Odleglosc")] Relacja relacja)
        {
            if (ModelState.IsValid)
            {
                db.Relacje.Add(relacja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relacja);
        }

        // GET: Relacje/Edit/5
        [Authorize(Users = "144070@stud.prz.edu.pl")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relacja relacja = db.Relacje.Find(id);
            if (relacja == null)
            {
                return HttpNotFound();
            }
            return View(relacja);
        }

        // POST: Relacje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Stacja_poczatkowa,Stacja_koncowa,Stacja_posrednia,Odleglosc")] Relacja relacja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relacja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relacja);
        }

        // GET: Relacje/Delete/5
        [Authorize(Users = "144070@stud.prz.edu.pl")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relacja relacja = db.Relacje.Find(id);
            if (relacja == null)
            {
                return HttpNotFound();
            }
            return View(relacja);
        }

        // POST: Relacje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Relacja relacja = db.Relacje.Find(id);
            db.Relacje.Remove(relacja);
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

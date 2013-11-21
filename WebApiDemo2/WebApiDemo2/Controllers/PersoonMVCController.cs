using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiDemo2.Controllers
{
    public class PersoonMVCController : Controller
    {
        private MijnContext db = new MijnContext();

        //
        // GET: /PersoonMVC/

        public ActionResult Index()
        {
            return View(db.Personen.ToList());
        }

        //
        // GET: /PersoonMVC/Details/5

        public ActionResult Details(int id = 0)
        {
            Persoon persoon = db.Personen.Find(id);
            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        //
        // GET: /PersoonMVC/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PersoonMVC/Create

        [HttpPost]
        public ActionResult Create(Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                db.Personen.Add(persoon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persoon);
        }

        //
        // GET: /PersoonMVC/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Persoon persoon = db.Personen.Find(id);
            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        //
        // POST: /PersoonMVC/Edit/5

        [HttpPost]
        public ActionResult Edit(Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persoon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persoon);
        }

        //
        // GET: /PersoonMVC/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Persoon persoon = db.Personen.Find(id);
            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        //
        // POST: /PersoonMVC/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Persoon persoon = db.Personen.Find(id);
            db.Personen.Remove(persoon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
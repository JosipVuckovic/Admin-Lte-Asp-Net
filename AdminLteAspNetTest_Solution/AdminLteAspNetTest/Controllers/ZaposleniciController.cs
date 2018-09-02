using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zaposlenici.Models;

namespace AdminLteAspNetTest.Controllers
{
    public class ZaposleniciController : Controller
    {
        private BazaZaposlenici db = new BazaZaposlenici();

        // GET: Zaposlenici
        public ActionResult Index()
        {
            return View(db.Zaposlenici.ToList());
        }

        // GET: Zaposlenici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposlenik zaposlenik = db.Zaposlenici.Find(id);
            if (zaposlenik == null)
            {
                return HttpNotFound();
            }
            return View(zaposlenik);
        }

        // GET: Zaposlenici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zaposlenici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ImeIPrezime,DatumRođenja,Adresa,KontaktBroj,KontaktEMail")] Zaposlenik zaposlenik)
        {
            if (ModelState.IsValid)
            {
                db.Zaposlenici.Add(zaposlenik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zaposlenik);
        }

        // GET: Zaposlenici/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposlenik zaposlenik = db.Zaposlenici.Find(id);
            if (zaposlenik == null)
            {
                return HttpNotFound();
            }
            return View(zaposlenik);
        }

        // POST: Zaposlenici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImeIPrezime,DatumRođenja,Adresa,KontaktBroj,KontaktEMail")] Zaposlenik zaposlenik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zaposlenik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zaposlenik);
        }

        // GET: Zaposlenici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposlenik zaposlenik = db.Zaposlenici.Find(id);
            if (zaposlenik == null)
            {
                return HttpNotFound();
            }
            return View(zaposlenik);
        }

        // POST: Zaposlenici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zaposlenik zaposlenik = db.Zaposlenici.Find(id);
            db.Zaposlenici.Remove(zaposlenik);
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

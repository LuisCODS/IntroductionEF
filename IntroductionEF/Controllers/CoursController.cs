using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntroductionEF.Models;

namespace IntroductionEF.Controllers
{
    public class CoursController : Controller
    {
        private Cegep db = new Cegep();

        // GET: Cours
        public ActionResult Index()
        {
            var cours = db.Cours.Include(c => c.Prof);
            return View(cours.ToList());
        }

        // GET: Cours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Cours.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // GET: Cours/Create
        public ActionResult Create()
        {
            ViewBag.FKProfID = new SelectList(db.Profs, "PKProfID", "nom");
            return View();
        }

        // POST: Cours/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PKCoursID,Nom,FKProfID")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Cours.Add(cours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKProfID = new SelectList(db.Profs, "PKProfID", "nom", cours.FKProfID);
            return View(cours);
        }

        // GET: Cours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Cours.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKProfID = new SelectList(db.Profs, "PKProfID", "nom", cours.FKProfID);
            return View(cours);
        }

        // POST: Cours/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PKCoursID,Nom,FKProfID")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKProfID = new SelectList(db.Profs, "PKProfID", "nom", cours.FKProfID);
            return View(cours);
        }

        // GET: Cours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Cours.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cours cours = db.Cours.Find(id);
            db.Cours.Remove(cours);
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

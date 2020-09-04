using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReservationVol5.Models;

namespace ReservationVol5.Controllers
{
    [Authorize(Roles = "User")]
    public class VolsController : Controller
    {
        private VolContext db = new VolContext();

        // GET: Vols
       
        public ActionResult Index()
        {
            return View(db.vols.ToList());
        }

        // GET: Vols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vol vol = db.vols.Find(id);
            if (vol == null)
            {
                return HttpNotFound();
            }
            return View(vol);
        }

        // GET: Vols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vols/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VolId,nomVol,siegePremiereClasse,siegeBusinessclass,siegeEconomyclass")] Vol vol)
        {
            if (ModelState.IsValid)
            {
                db.vols.Add(vol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vol);
        }

        // GET: Vols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vol vol = db.vols.Find(id);
            if (vol == null)
            {
                return HttpNotFound();
            }
            return View(vol);
        }

        // POST: Vols/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VolId,nomVol,siegePremiereClasse,siegeBusinessclass,siegeEconomyclass")] Vol vol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vol);
        }

        // GET: Vols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vol vol = db.vols.Find(id);
            if (vol == null)
            {
                return HttpNotFound();
            }
            return View(vol);
        }

        // POST: Vols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vol vol = db.vols.Find(id);
            db.vols.Remove(vol);
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

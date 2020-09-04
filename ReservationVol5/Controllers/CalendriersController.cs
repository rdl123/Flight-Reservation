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
    [Authorize]
    public class CalendriersController : Controller
    {
        private VolContext db = new VolContext();

        // GET: Calendriers
        public ActionResult Index()
        {
            var calendrier = db.calendrier.Include(c => c.vol);
            return View(calendrier.ToList());
        }

        // GET: Calendriers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendrier calendrier = db.calendrier.Find(id);
            if (calendrier == null)
            {
                return HttpNotFound();
            }
            return View(calendrier);
        }

        // GET: Calendriers/Create
        public ActionResult Create()
        {
            ViewBag.volId = new SelectList(db.vols, "VolId", "nomVol");
            return View();
        }

        // POST: Calendriers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "calendrierId,volId,destination,destinationId,calendrierDate,tempsdepart,datearrivee,tempsarrivee,siegepremiereClassrestant,siegeBuisnissClassrestant,siegeeconomieClassrestant,prixpremiere,prixBuisniss,prixeconomie")] Calendrier calendrier)
        {
            if (ModelState.IsValid)
            {
                db.calendrier.Add(calendrier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.volId = new SelectList(db.vols, "VolId", "nomVol", calendrier.volId);
            return View(calendrier);
        }

        // GET: Calendriers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendrier calendrier = db.calendrier.Find(id);
            if (calendrier == null)
            {
                return HttpNotFound();
            }
            ViewBag.volId = new SelectList(db.vols, "VolId", "nomVol", calendrier.volId);
            return View(calendrier);
        }

        // POST: Calendriers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "calendrierId,volId,destination,destinationId,calendrierDate,tempsdepart,datearrivee,tempsarrivee,siegepremiereClassrestant,siegeBuisnissClassrestant,siegeeconomieClassrestant,prixpremiere,prixBuisniss,prixeconomie")] Calendrier calendrier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendrier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.volId = new SelectList(db.vols, "VolId", "nomVol", calendrier.volId);
            return View(calendrier);
        }

        // GET: Calendriers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendrier calendrier = db.calendrier.Find(id);
            if (calendrier == null)
            {
                return HttpNotFound();
            }
            return View(calendrier);
        }

        // POST: Calendriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calendrier calendrier = db.calendrier.Find(id);
            db.calendrier.Remove(calendrier);
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

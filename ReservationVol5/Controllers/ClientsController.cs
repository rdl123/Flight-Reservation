using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReservationVol5.Models;

namespace ReservationVol5.Controllers
{
    public class ClientsController : Controller
    {
        private VolContext db = new VolContext();

        // GET: Clients
        [Authorize(Roles="User")]
        public ActionResult Index()
        {
            var clients = db.clients.Include(c => c.Calendrier).Include(c => c.Vol);
            return View(clients.ToList());
        }
        public ActionResult Reserver(int sid, int fid, DateTime doj, string name, string Tclass)
        {

            Client model = new Client()
            {
               volId = fid,
               calendrierId = sid,
               datevol = doj.Date,
                typeclasse = Tclass
              
            };
            ViewBag.nomVol= name;

            return View(model);
        }
        public ActionResult Payment([Bind(Include = "VolId,calendrierId,datevol,nomclient,sexe,numeroTelephone,addresse,typeclasse")] Client Billet)
        {
            TempData["Billet"] =  Billet;
            Billet.numerosiege = db.clients.Include(t => t.ClientId).Where(t => t.typeclasse == Billet.typeclasse).Count() + 1;
            //Payement payment = new Payement()
            //{
            //    prixTotal = getcostofticket(Billet.calendrierId, Billet.typeclasse)
            //};

            ViewBag.Message = "Merci pour votre Confiance ";

            return View();
        }
        //private double getcostofticket(int calendrierId, string typeclasse) 
        //{
        //    double cost = 0.00;
        //    Calendrier s = new Calendrier();
        //    var query = "SELECT 'prix" + typeclasse + "' FROM calendrier where calendrierId=" + calendrierId;
        //    //string cString = ConfigurationManager.ConnectionStrings["FlightReservationSystemContext"].ConnectionString;
        //    string cString = "Data Source=.;Initial Catalog = VolDB; Integrated Security = SSPI";
        //    try
        //    {
        //        using (SqlConnection c = new SqlConnection(cString))
        //        {
        //            c.Open();
        //            using (SqlCommand cmd = new SqlCommand(query, c))
        //            {
        //                using (SqlDataReader rdr = cmd.ExecuteReader())
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        cost = rdr.GetDouble(rdr.GetOrdinal("prix" + typeclasse));
        //                    }
        //                }
        //            }
        //        }
              
        //    }
        //    catch (Exception IndexOutOfRangeException)
        //    {
        //        throw IndexOutOfRangeException;
        //    };

        //    return (cost);
        //}

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.calendrierId = new SelectList(db.calendrier, "calendrierId", "source");
            ViewBag.volId = new SelectList(db.vols, "VolId", "nomVol");
            return View();
        }

        // POST: Clients/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,volId,calendrierId,datevol,numerosiege,nomclient,prenomclient,emaiclient,numeroTelephone,addresse,typeclasse")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.calendrierId = new SelectList(db.calendrier, "calendrierId", "source", client.calendrierId);
            ViewBag.volId = new SelectList(db.vols, "VolId", "nomVol", client.volId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.calendrierId = new SelectList(db.calendrier, "calendrierId", "source", client.calendrierId);
            ViewBag.volId = new SelectList(db.vols, "VolId", "nomVol", client.volId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,volId,calendrierId,datevol,numerosiege,nomclient,prenomclient,emaiclient,numeroTelephone,addresse,typeclasse")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.calendrierId = new SelectList(db.calendrier, "calendrierId", "source", client.calendrierId);
            ViewBag.volId = new SelectList(db.vols, "VolId", "nomVol", client.volId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.clients.Find(id);
            db.clients.Remove(client);
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

using ReservationVol5.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationVol5.Controllers
{
    public class HomeController : Controller
    {
        private VolContext db = new VolContext();

        [Authorize]
        public ActionResult Index()
        {

            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            var srclist = new List<Calendrier>();
            var destlist = new List<Calendrier>();
           // string cString = ConfigurationManager.ConnectionStrings["VolContext"].ConnectionString;
            string cString = "Data Source=.;Initial Catalog = VolDB; Integrated Security = SSPI";
            using (SqlConnection c = new SqlConnection(cString))
            {
                c.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT source FROM Calendriers", c))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            srclist.Add(new Calendrier
                            {
                                source = rdr.GetString(0)
                            });
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT destination FROM Calendriers", c))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            destlist.Add(new Calendrier
                            {
                                destination = rdr.GetString(0)
                            });
                        }
                    }
                }
            }

            ViewBag.source = new SelectList(srclist, "source", "source");
            ViewBag.dest = new SelectList(destlist, "destination", "destination");
            ViewBag.date = new DateTime();
            return View();

        }
        public ActionResult homePage()
        {
            return View();
        }
        [Authorize]
        public ActionResult SearchResults(string source, string dest, DateTime dateOfJourney)
        {


            ViewBag.Source = source;
            ViewBag.Dest = dest;
            ViewBag.ScheduleMessage = "";
            if (DateTime.Compare(dateOfJourney, DateTime.Today) > 0)
            {
                var data = from s in db.calendrier
                           where s.source == source && s.destination == dest && s.calendrierDate == dateOfJourney
                           select s;
                if (data.ToList().Count() == 0)
                {
                    ViewBag.ScheduleMessage = "Aucun vol à la date saisie, voici les vols des autres jours";
                    data = from s in db.calendrier
                           where s.source == source && s.destination == dest && DateTime.Compare(s.calendrierDate, DateTime.Today) > 0
                           select s;
                }
                return View(data.ToList());
            }
            else
            {
                var data = from s in db.calendrier
                           where s.source == source && s.destination == dest && DateTime.Compare(s.calendrierDate, DateTime.Today) >= 0
                           select s;
                if (dateOfJourney.CompareTo(DateTime.Today) == 0)
                    ViewBag.ScheduleMessage = "Impossible de réserver des vols pour aujourd'hui pour la source et la destination demandées. Les vols de la source demandée à la destination sont répertoriés ci-dessous";
                else
                    ViewBag.ScheduleMessage = "Date passée entrée, les vols de la source demandée à la destination sont listés ci-dessous";
                return View(data.ToList());

            }

        }

      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
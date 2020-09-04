using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationVol5.Models
{
    public class Volinitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<VolContext>
    {
        protected override void Seed(VolContext context)
        {
            var vol = new List<Vol>
            {
                new Vol { VolId = 1, nomVol = "RAM", siegePremiereClasse = 40, siegeBusinessclass = 10, siegeEconomyclass = 60 },
                new Vol { VolId = 2, nomVol = "Morrocan Airways0", siegePremiereClasse = 40, siegeBusinessclass = 10, siegeEconomyclass = 60 },
                new Vol { VolId = 3, nomVol = "Emirates Airways", siegePremiereClasse = 40, siegeBusinessclass = 10, siegeEconomyclass = 60 },
                new Vol { VolId = 4, nomVol = "Morrocan Airways1", siegePremiereClasse = 40, siegeBusinessclass = 10, siegeEconomyclass = 60 },
                new Vol { VolId = 5, nomVol = "Morrocan Airways2", siegePremiereClasse = 40, siegeBusinessclass = 10, siegeEconomyclass = 60 },
                new Vol { VolId = 6, nomVol = "Morrocan Airways3", siegePremiereClasse = 40, siegeBusinessclass = 10, siegeEconomyclass = 60 },
            };
            vol.ForEach(s => context.vols.Add(s));
            context.SaveChanges();
            var calendrier = new List<Calendrier>
            {

                new Calendrier { calendrierId = 1, volId = 1,source = "Casa" , destination = "France", destinationId = 10, calendrierDate = new DateTime(2020, 01, 17), tempsdepart = new TimeSpan(2, 14, 18), datearrivee = new DateTime(2020, 01, 17), tempsarrivee = new TimeSpan(4, 34, 50), siegepremiereClassrestant = 20, siegeBuisnissClassrestant = 28, siegeeconomieClassrestant = 50, prixpremiere = 3000.00, prixBuisniss = 5000.00, prixeconomie = 2000.00 },
                new Calendrier { calendrierId = 2, volId = 2,source = "Rabat" , destination = "Agadir", destinationId = 11, calendrierDate = new DateTime(2020, 02, 02), tempsdepart = new TimeSpan(2, 14, 18), datearrivee = new DateTime(2020, 01, 17), tempsarrivee = new TimeSpan(4, 34, 50), siegepremiereClassrestant = 20, siegeBuisnissClassrestant = 28, siegeeconomieClassrestant = 50, prixpremiere = 3000.00, prixBuisniss = 5000.00, prixeconomie = 2000.00 },
                new Calendrier { calendrierId = 3, volId = 3,source = "Agadir" , destination = "Uk", destinationId = 12, calendrierDate = new DateTime(2020, 02, 17), tempsdepart = new TimeSpan(2, 14, 18), datearrivee = new DateTime(2020, 01, 17), tempsarrivee = new TimeSpan(4, 34, 50), siegepremiereClassrestant = 20, siegeBuisnissClassrestant = 28, siegeeconomieClassrestant = 50, prixpremiere = 3000.00, prixBuisniss = 5000.00, prixeconomie = 2000.00 },
                new Calendrier { calendrierId = 4, volId = 4,source = "Tunisie" , destination = "Tanger", destinationId = 13, calendrierDate = new DateTime(2020, 03, 17), tempsdepart = new TimeSpan(2, 14, 18), datearrivee = new DateTime(2020, 01, 17), tempsarrivee = new TimeSpan(4, 34, 50), siegepremiereClassrestant = 20, siegeBuisnissClassrestant = 28, siegeeconomieClassrestant = 50, prixpremiere = 3000.00, prixBuisniss = 5000.00, prixeconomie = 2000.00 },
                new Calendrier { calendrierId = 5, volId = 5,source = "Egypte" , destination = "Canada", destinationId = 14, calendrierDate = new DateTime(2020, 02, 20), tempsdepart = new TimeSpan(2, 14, 18), datearrivee = new DateTime(2020, 01, 17), tempsarrivee = new TimeSpan(4, 34, 50), siegepremiereClassrestant = 20, siegeBuisnissClassrestant = 28, siegeeconomieClassrestant = 50, prixpremiere = 3000.00, prixBuisniss = 5000.00, prixeconomie = 2000.00 },
            };
            calendrier.ForEach(s => context.calendrier.Add(s));
            context.SaveChanges();
            var clients = new List<Client>
            {
            new Client{ClientId =1, volId = 1, calendrierId = 1, datevol = new DateTime(2015,11,30),numerosiege= 22, nomclient= "ali",prenomclient="soualy",emaiclient="alisoualy@gmail.com",sexe= 'H', numeroTelephone = "0617181920", addresse = "Ehtp",typeclasse= "Business"},
            new Client{ClientId = 2, volId = 2, calendrierId = 2, datevol = new DateTime(2015,11,30),numerosiege= 20, nomclient= "moad",prenomclient="Ait Laarbi",emaiclient="moadaitlaarbi@gmail.com",sexe= 'H', numeroTelephone = "061718123", addresse = "OULFA",typeclasse= "Business"},
            new Client{ClientId = 3, volId = 3, calendrierId = 3, datevol = new DateTime(2015,11,30),numerosiege= 30, nomclient= "yassine",prenomclient="Zouhri",emaiclient="zouhriyassisne@gmail.com",sexe= 'H', numeroTelephone = "061714566", addresse = "BOURGON",typeclasse= "Business"},
            new Client{ClientId = 4, volId = 4, calendrierId = 4, datevol = new DateTime(2015,11,30),numerosiege= 10, nomclient= "Rami",prenomclient="Rachid",emaiclient="ramirachid@gmail.com",sexe= 'H', numeroTelephone = "061717899", addresse = "GHANDI",typeclasse= "Business"},
            };
            clients.ForEach(s => context.clients.Add(s));
            context.SaveChanges();

            var payement = new List<Payement>
            {
                new Payement { IdPayment = 1, modePayment = "Visa", prixTotal = 600.00 },
                new Payement { IdPayment = 1, modePayment = "Visa", prixTotal = 600.00 },
                new Payement { IdPayment = 1, modePayment = "Visa", prixTotal = 600.00 },
                new Payement { IdPayment = 1, modePayment = "Visa", prixTotal = 600.00 },
                new Payement { IdPayment = 1, modePayment = "Visa", prixTotal = 600.00 },
            };

            payement.ForEach(s => context.payement.Add(s));
            context.SaveChanges();
        }

    }
}
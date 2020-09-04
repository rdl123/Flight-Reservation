using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ReservationVol5.Models
{
    public class VolContext : System.Data.Entity.DbContext
    {
           public VolContext() : base("name=VolDB") { }
        public DbSet<Vol> vols { get; set; }
        public DbSet<Calendrier> calendrier { get; set; }
        public DbSet<Payement> payement { get; set; }
        public DbSet<Client> clients { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
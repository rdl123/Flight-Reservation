using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReservationVol5.Models
{
    [Table("Payement")]
    public class Payement
    {
        [Key]
        public int IdPayment { get; set; }
        public string modePayment { get; set; }
        public double prixTotal { get; set; }
        public virtual ICollection<Client> Client { get; set; }
    }
}
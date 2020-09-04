using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReservationVol5.Models
{
    [Table("Vol")]
    public class Vol
    {
        //[Required]
        //[Key]
        public int VolId { get; set; }
        [Required]
        public string nomVol { get; set; }
        [Required]
        public int siegePremiereClasse { get; set; }
        [Required]
        public int  siegeBusinessclass { get; set; }
        [Required]
        public int siegeEconomyclass { get; set; }
        public virtual ICollection<Calendrier> Calendriers{ get; set; }

    }
}
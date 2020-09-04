using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReservationVol5.Models
{
    [Table("Client")]
    public class Client
    {
        [Required]
        [Key]


        public int ClientId { get; set; }
        
       // [ForeignKey("Vol")]
        public int volId { get; set; }
        //[ForeignKey("Calendrier")]
        public int calendrierId { get; set; }
        [DataType(DataType.Date)]
        public DateTime datevol { get; set; }
        public int numerosiege { get; set; }
        public string nomclient { get; set; }
        public string prenomclient { get; set; }
        public string emaiclient { get; set; }
        public char sexe { get; set; }
        [Phone]
        public string numeroTelephone { get; set; }
        public string addresse { get; set; }

        public string typeclasse { get; set; }

        public virtual Vol Vol { get; set; }
        public virtual Calendrier Calendrier { get; set; }
        public virtual Payement Payement { get; set; }
      
    }
}
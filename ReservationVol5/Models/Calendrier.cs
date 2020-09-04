using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReservationVol5.Models
{
    public class Calendrier
    {
       // [Key]
        public int calendrierId { get; set; }

      // [ForeignKey("Vol")]
        public int volId { get; set; }
        [Required]
        public string source { get; set; }
        public string destination { get; set; }
        [Required]
        public int destinationId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime calendrierDate { get; set; }
        [Required]
        public TimeSpan tempsdepart { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime datearrivee { get; set; }
        [Required]
        public TimeSpan tempsarrivee { get; set; }
        [Required]
        
        public int siegepremiereClassrestant { get; set; } 
        [Required]
        public int siegeBuisnissClassrestant { get; set; } 
        [Required]
        public int siegeeconomieClassrestant { get; set; } 
        [Required]
        public double prixpremiere { get; set; }
        [Required]
        public double prixBuisniss { get; set; }
        [Required]
        public double prixeconomie { get; set; }
        [Required]
       


        public virtual Vol vol { get; set; }
  
    }
}
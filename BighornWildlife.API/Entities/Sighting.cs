using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BighornWildlife.API.Entities
{
    public class Sighting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SpecieId { get; set; }

        [ForeignKey("SpecieId")]
        public Specie Specie { get; set; }

        [Required]
        public float Longitude { get; set; }

        [Required]
        public float Latitude { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }
    }
}
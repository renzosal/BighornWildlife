using BighornWildlife.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BighornWildlife.API.Entities
{
    public class Specie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public WildlifeTypes WildlifeType { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Sighting> Sightings { get; set; }
    }
}
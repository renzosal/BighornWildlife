using BighornWildlife.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BighornWildlife.API
{
    public class BighornContext : DbContext
    {
        public BighornContext()
            :base("BighornContext")
        {

        }

        public DbSet<Specie> Species { get; set; }
        public DbSet<Sighting> Sightings { get; set; }
    }
}
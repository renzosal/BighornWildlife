using BighornWildlife.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BighornWildlife.API
{
    public class BighornRepository : IDisposable
    {
        private BighornContext _ctx;

        public BighornRepository()
        {
            _ctx = new BighornContext();
        }

        public IEnumerable<Specie> GetAllSpecies() {

            return _ctx.Species.ToList();
        }

        public Specie FindSpecieById(int id)
        {
            return _ctx.Species.Find(id);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
using BighornWildlife.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BighornWildlife.API.Controllers
{
    [RoutePrefix("api/Species")]
    public class SpeciesController : ApiController
    {
        private BighornRepository _repo = null;

        public SpeciesController()
        {
            _repo = new BighornRepository();
        }

        //GET api/Species
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            string Domain = Helper.GetRequestDomain(Request);

            var allSpecies = _repo.GetAllSpecies();
            foreach (var specie in allSpecies)
            {
                if (!string.IsNullOrEmpty(specie.Image))
                {
                    specie.Image = Domain + "/Images/" + specie.Image;
                }
            }
            return Ok(allSpecies);
        }

        //GET api/Species/5
        [AllowAnonymous]
        public IHttpActionResult GetSpecie(int id)
        {
            var Domain = Helper.GetRequestDomain(Request);
            var specie = new Specie();
            specie = _repo.FindSpecieById(id);

            if (specie == null)
            {
                return NotFound();
            }
            else
            {
                if (!string.IsNullOrEmpty(specie.Image))
                {
                    specie.Image = Domain + "/Images/" + specie.Image;
                }
                return Ok(specie);
            }
        }
    }
}

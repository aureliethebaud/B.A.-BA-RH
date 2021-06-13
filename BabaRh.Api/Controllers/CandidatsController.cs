using BabaRh.AccessLayer.EntityFramework.AccessLayers;
using BabaRh.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BabaRh.Api.Controllers
{
    public class CandidatsController : ApiController
    {
        private readonly CandidatAccessLayer candidatAccessLayer = CandidatAccessLayer.Instance;

        // GET api/candidats
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = candidatAccessLayer.GetAll();

            return this.Ok(result);
        }



        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Candidat candidat)
        {
            var pizzaToAdd = new AccessLayer.Models.Candidat
            {
                Nom = candidat.Nom,
                Prenom = candidat.Prenom,
            };

            await candidatAccessLayer.AddAsync(pizzaToAdd);
            return this.Ok("created");
        }
    }
}

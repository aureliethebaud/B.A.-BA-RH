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

        // GET api/candidats/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = candidatAccessLayer.Get(id);

            return this.Ok(result);
        }


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
            var candidatToAdd = new AccessLayer.Models.Candidat
            {
                Nom = candidat.Nom,
                Prenom = candidat.Prenom,
            };

            await candidatAccessLayer.AddAsync(candidatToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateAsync([FromBody] Candidat candidat)
        {
            var candidatToUpdate = new AccessLayer.Models.Candidat
            {
                CandidatId = candidat.Id,
                Nom = candidat.Nom,
                Prenom = candidat.Prenom
            };

            await candidatAccessLayer.UpdateAsync(candidatToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var candidatToDelete = candidatAccessLayer.Get(id);

            if (candidatToDelete == null)
            {
                return this.NotFound();
            }

            await candidatAccessLayer.DeleteAsync(candidatToDelete.CandidatId);
            return this.Ok("Delete");
        }

    }
}

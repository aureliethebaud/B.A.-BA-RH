namespace BabaRh.Api.Controllers
{
    using BabaRh.AccessLayer.EntityFramework.AccessLayers;
    using BabaRh.Api.Models;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class NiveauxController : ApiController
    {
        private readonly NiveauAccessLayer niveauAccessLayer = NiveauAccessLayer.Instance;
        

        // GET api/niveaux
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = niveauAccessLayer.GetAll().Select(n => new Niveau
            {
                NiveauId = n.NiveauId,                
                NiveauLib = n.NiveauLib                
            });
            return this.Ok(result);
        }


        // GET api/niveaux/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDb = niveauAccessLayer.Get(id);

            if (fromDb == null)
                return this.NotFound();

            var result = new Niveau
            {
                NiveauId = fromDb.NiveauId,                
                NiveauLib = fromDb.NiveauLib,                
            };

            return this.Ok(result);
        }

            [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Niveau niveau)
        {

            var niveauToAdd = new AccessLayer.Models.Niveau
            {
                NiveauLib = niveau.NiveauLib
            };


            await niveauAccessLayer.AddAsync(niveauToAdd);
            return this.Ok("created");
        }



        [HttpPut]
        public async Task<IHttpActionResult> UpdateAsync([FromBody] Niveau niveau)
        {
            var niveauToUpdate = new AccessLayer.Models.Niveau
            {
                NiveauId = niveau.NiveauId,
                NiveauLib = niveau.NiveauLib
            };

            await niveauAccessLayer.UpdateAsync(niveauToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var niveauToDelete = niveauAccessLayer.Get(id);

            if (niveauToDelete == null)
            {
                return this.NotFound();
            }

            await niveauAccessLayer.DeleteAsync(niveauToDelete.NiveauId);
            return this.Ok("Delete");
        }

    }
}


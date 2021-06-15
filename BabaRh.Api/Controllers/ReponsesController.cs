using BabaRh.AccessLayer.EntityFramework.AccessLayers;
using BabaRh.Api.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;


namespace BabaRh.Api.Controllers
{
    public class ReponsesController : ApiController
    {
        private readonly ReponseAccessLayer reponseAccessLayer = ReponseAccessLayer.Instance;
        

        // GET api/reponses/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDb = reponseAccessLayer.Get(id);

            if (fromDb == null)
                return this.NotFound();

            var result = new Reponse
            {
                ReponseId = fromDb.ReponseId,                
                //Question = new Question { QuestionId = fromDb.QuestionId, QuestionLib = fromDb.Question.QuestionLib },
                ReponseLib = fromDb.ReponseLib,
                IsOk = fromDb.IsOk
            };

            return this.Ok(result);
        }


        


        // GET api/reponses
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = reponseAccessLayer.GetAll().Select(r => new Reponse
            {
                ReponseId = r.ReponseId,                
                //Question = new Question { QuestionId = r.Question.QuestionId, QuestionLib = r.Question.QuestionLib },
                ReponseLib = r.ReponseLib,
                IsOk = r.IsOk
            });

            return this.Ok(result);
        }



        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Reponse reponse)
        {
            var reponseToAdd = new AccessLayer.Models.Reponse
            {
                ReponseLib = reponse.ReponseLib,
                IsOk = reponse.IsOk
            };

            await reponseAccessLayer.AddAsync(reponseToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateAsync([FromBody] Reponse reponse)
        {
            var reponseToUpdate = new AccessLayer.Models.Reponse
            {
                ReponseId = reponse.ReponseId,
                ReponseLib = reponse.ReponseLib,
                IsOk = reponse.IsOk
            };

            await reponseAccessLayer.UpdateAsync(reponseToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var reponseToDelete = reponseAccessLayer.Get(id);

            if (reponseToDelete == null)
            {
                return this.NotFound();
            }

            await reponseAccessLayer.DeleteAsync(reponseToDelete.ReponseId);
            return this.Ok("Delete");
        }

    }
}
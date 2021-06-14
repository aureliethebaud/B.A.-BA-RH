namespace BabaRh.Api.Controllers
{
    using BabaRh.AccessLayer.EntityFramework.AccessLayers;
    using BabaRh.Api.Models;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class QuestionsController : ApiController
    {
        private readonly QuestionAccessLayer questionAccessLayer = QuestionAccessLayer.Instance;
        

        // GET api/questions/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDb = questionAccessLayer.Get(id);

            if (fromDb == null)
                return this.NotFound();

            var result = new Question
            {
                QuestionId = fromDb.QuestionId,                
                QuestionLib = fromDb.QuestionLib,
                Niveau = Niveau.Confirmé,
                ModuleLib = fromDb.ModuleLib,
                QuestionOuverte = fromDb.QuestionOuverte,
                
            };

            return this.Ok(result);
        }





        // GET api/questions
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = questionAccessLayer.GetAll().Select(q => new Question
            {
                QuestionId = q.QuestionId,
                QuestionLib = q.QuestionLib,     
                Niveau = Niveau.Confirmé,
                ModuleLib = q.ModuleLib,
                QuestionOuverte = q.QuestionOuverte,

            }) ;

            return this.Ok(result);
        }



        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Question question)
        {
            var questionToAdd = new AccessLayer.Models.Question
            {
                QuestionLib = question.QuestionLib,                
                ModuleLib = question.ModuleLib,
                QuestionOuverte = question.QuestionOuverte,
                
            };

            await questionAccessLayer.AddAsync(questionToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateAsync([FromBody] Question question)
        {
            var questionToUpdate = new AccessLayer.Models.Question
            {
                QuestionId = question.QuestionId,
                QuestionLib = question.QuestionLib,                
                ModuleLib = question.ModuleLib,
                QuestionOuverte = question.QuestionOuverte,
            };

            await questionAccessLayer.UpdateAsync(questionToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var questionToDelete = questionAccessLayer.Get(id);

            if (questionToDelete == null)
            {
                return this.NotFound();
            }

            await questionAccessLayer.DeleteAsync(questionToDelete.QuestionId);
            return this.Ok("Delete");
        }

    }
}

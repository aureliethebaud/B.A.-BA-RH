using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BabaRh.Api.Controllers
{
    using BabaRh.AccessLayer.EntityFramework.AccessLayers;
    using BabaRh.Api.Models;
    using System.Threading.Tasks;

    public class QuizzesController : ApiController
    { 
        private readonly QuizzAccessLayer quizzAccessLayer = QuizzAccessLayer.Instance;

        // GET api/quizzes
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var fromDb = quizzAccessLayer.GetAll();
            var result = new List<Quizz>();

            foreach (var quizz in fromDb)
            {
                result.Add(new Quizz
                {
                    QuizzId = quizz.QuizzId,
                    Candidat = new Candidat
                    {
                        Id = quizz.CandidatId,
                        Prenom = quizz.Candidat.Prenom,
                        Nom = quizz.Candidat.Nom
                    },
                    Modules = quizz.QuizzModule.Select(qm => new Module
                    {
                        ModuleLib = qm.ModuleLib
                    }).ToList()
                });
                
            }
            return this.Ok(result);
        }

        // GET api/quizzes/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDb = quizzAccessLayer.Get(id);

            var result = new Quizz
            {
                Questions = fromDb.QuizzQuestion.Select(qq => new Question
                {
                    Id = qq.Question.QuestionId,
                    ModuleLib = qq.Question.ModuleLib,
                    Niveau = (Niveau)qq.Question.Niveau,
                    QuestionLib = qq.Question.QuestionLib,
                    QuestionOuverte = qq.Question.QuestionOuverte,
                    Reponses = qq.Question.Reponse.Select(r => new Reponse
                    {
                        Id = r.ReponseId,
                        IsOK = r.IsOk,
                        ReponseLib = r.ReponseLib
                    }).ToList()
                }).ToList(),
                Candidat = new Candidat
                {
                    Id = fromDb.CandidatId,
                    Prenom = fromDb.Candidat.Prenom,
                    Nom = fromDb.Candidat.Nom
                },
                NbQuestion = fromDb.NbQuestion,
                QuizzId = fromDb.QuizzId,
                Timer = fromDb.Timer,
                Url = fromDb.Url,
                Modules = fromDb.QuizzModule.Select(qm => new Module
                {
                    ModuleLib = qm.ModuleLib
                }).ToList()
            };
            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Quizz quizz)
        {
            var quizzToAdd = new AccessLayer.Models.Quizz
            {
                CandidatId = quizz.Candidat.Id,
                NbQuestion = quizz.NbQuestion,
                Timer = quizz.Timer,
                Url = quizz.Url,
            };

            quizzToAdd.QuizzModule = quizz.Modules.Select(mq => new AccessLayer.Models.QuizzModule { ModuleLib = mq.ModuleLib, QuizzId = quizzToAdd.QuizzId }).ToList();
            quizzToAdd.QuizzQuestion = quizz.Questions.Select(qq => new AccessLayer.Models.QuizzQuestion { QuestionId = qq.Id, QuizzId = quizzToAdd.QuizzId }).ToList();

            await quizzAccessLayer.AddAsync(quizzToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateAsync([FromBody] Quizz quizz)
        {
            var quizzToUpdate = new AccessLayer.Models.Quizz
            {
                Candidat = new AccessLayer.Models.Candidat
                {
                    CandidatId = quizz.Candidat.Id,
                    Nom = quizz.Candidat.Nom,
                    Prenom = quizz.Candidat.Prenom
                },
                NbQuestion = quizz.NbQuestion,
                Timer = quizz.Timer,
                Url = quizz.Url,
            };

            await quizzAccessLayer.UpdateAsync(quizzToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var quizzToDelete = quizzAccessLayer.Get(id);

            if (quizzToDelete == null)
            {
                return this.NotFound();
            }

            await quizzAccessLayer.DeleteAsync(quizzToDelete.CandidatId);
            return this.Ok("Delete");
        }


    }
}

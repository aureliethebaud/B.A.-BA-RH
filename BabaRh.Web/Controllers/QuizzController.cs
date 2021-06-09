using BabaRh.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BabaRh.Web.Models.ViewModel;

namespace BabaRh.Web.Controllers
{
    public class QuizzController : Controller
    {
        private readonly QuizzService quizzService = new QuizzService();

        // GET: Quizzes/Details/id
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quizzGetted = await quizzService.Get((int)id);
            QuizzVM quizz = new QuizzVM()
            {
                Quizz = new Quizz()
                {
                    Module = quizzGetted.Module,
                    CandidatId = quizzGetted.CandidatId,
                    NbQuestion = quizzGetted.NbQuestion,
                    Question = quizzGetted.Question,
                    QuizzId = quizzGetted.QuizzId,
                    Timer = quizzGetted.Timer,
                    Url = quizzGetted.Url
                }
            };


            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz);
        }

    }
}
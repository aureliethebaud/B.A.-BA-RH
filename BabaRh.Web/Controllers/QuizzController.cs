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
        private readonly ModuleService moduleService = new ModuleService();

        // GET: Quizzes/Details/id
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quizz = await quizzService.Get((int)id);

            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz);
        }

    }
}
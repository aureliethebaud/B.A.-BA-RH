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
        private readonly CandidatService candidatService = new CandidatService();
        private readonly QuestionsService questionService = new QuestionsService();
        private readonly ModulesService moduleService = new ModulesService();

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

        // GET: Quizzes/Details/id
        public async Task<ActionResult> Index()
        {
            var quizzes = await quizzService.GetAll();

            if (quizzes == null)
            {
                return HttpNotFound();
            }
            return View(quizzes);
        }

        // GET: Quizzes/Create
        public async Task<ActionResult> Create()
        {
            var module = (await moduleService.GetAll());
            for (int i = 0; i < module.Count; i++)
            {
                module[i].ModuleId = i+1;
            }

            var candidats = new SelectList(await candidatService.GetAll(), "Id", "Nom");
            var modules = new SelectList(await moduleService.GetAll(), "ModuleId", "ModuleLib");
            var questions = new SelectList(await questionService.GetAll(), "QuestionId", "QuestionLib");

            //var questions = new SelectList(await questionService.GetAll(), "Param1", "Param2", "...");

            var vm = new QuizzCreateUpdateVM
            {
                AvailableCandidats = candidats,
                AvailableModules = modules,
                AvailableQuestions = questions,
            };

            return View(vm);
        }

        // POST: Quizzes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuizzCreateUpdateVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.Quizz.Candidat = new CandidatVM { Id = vm.SelectedCandidatId };
                vm.Quizz.Modules = vm.SelectedModulesLibs.Select(l => new ModuleVM { ModuleId = l }).ToList();
                vm.Quizz.Questions = new List<QuestionVM>();
                foreach (var module in vm.Quizz.Modules)
                {
                    vm.Quizz.Questions.AddRange((await questionService.GetAll()).Where(q => q.Module.ModuleId == module.ModuleId));
                }

                vm.Quizz.NbQuestion = vm.Quizz.Questions.Count();

                await quizzService.Create(vm.Quizz);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Quizz/Edit/id
        public async Task<ActionResult> Edit(int? id)
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

            var quizzToUpdate = await quizzService.Get((int)id);

            var module = (await moduleService.GetAll());
            for (int i = 0; i < module.Count; i++)
            {
                module[i].ModuleId = i + 1;
            }

            var candidats = new SelectList(await candidatService.GetAll(), "Id", "Nom");
            var modules = new SelectList(await moduleService.GetAll(), "ModuleId", "ModuleLib");
            var questions = new SelectList(await questionService.GetAll(), "QuestionId", "QuestionLib");

            //var questions = new SelectList(await questionService.GetAll(), "Param1", "Param2", "...");

            var vm = new QuizzCreateUpdateVM
            {
                AvailableCandidats = candidats,
                AvailableModules = modules,
                AvailableQuestions = questions,
                SelectedCandidatId = quizz.Candidat.Id,
                SelectedModulesLibs = quizz.Modules.Select(m => m.ModuleId).ToList(),
                Quizz = quizz
            };

            return View(vm);

        }

        // POST: Quizz/Edit/id
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(QuizzCreateUpdateVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.Quizz.Candidat = new CandidatVM { Id = vm.SelectedCandidatId };
                vm.Quizz.Modules = vm.SelectedModulesLibs.Select(l => new ModuleVM { ModuleId = l }).ToList();
                vm.Quizz.Questions = new List<QuestionVM>();
                foreach (var module in vm.Quizz.Modules)
                {
                    vm.Quizz.Questions.AddRange((await questionService.GetAll()).Where(q => q.Module.ModuleId == module.ModuleId));
                }

                vm.Quizz.NbQuestion = vm.Quizz.Questions.Count();

                await quizzService.Create(vm.Quizz);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Quizz/Delete/id
        public async Task<ActionResult> Delete(int? id)
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

        // POST: Quizz/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await quizzService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
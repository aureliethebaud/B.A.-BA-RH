namespace BabaRh.Web.Controllers
{
    using BabaRh.Web.Models.ViewModel;
    using BabaRh.Web.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class QuestionsController : Controller
    {
        private readonly QuestionsService questionsService = new QuestionsService();
        private readonly ModulesService modulesService = new ModulesService();
        private readonly NiveauxService niveauxService = new NiveauxService();
        private readonly ReponsesService reponsesService = new ReponsesService();

        // GET: Questions/Index
        public async Task<ActionResult> Index()
        {
            var questions = await questionsService.GetAll();

            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        // GET: Questions/Create
        public async Task<ActionResult> Create()
        {
            var modules = new SelectList(await modulesService.GetAll(), "ModuleId", "ModuleLib");
            var niveaux = new SelectList(await niveauxService.GetAll(), "NiveauId", "NiveauLib");
           

            var vm = new QuestionCreateUpdateVM()
            {
                AvailableModules = modules,
                AvailableNiveaux = niveaux,                      
            };

            
            
            return View(vm);
        }

        // POST: Reponses/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuestionCreateUpdateVM vm)
        {
            if (ModelState.IsValid)
            {

                vm.Question.Module = new ModuleVM { ModuleId = vm.SelectedModuleId };
                vm.Question.Niveau = new NiveauVM { NiveauId = vm.SelectedNiveauId };
                
                await questionsService.Create(vm.Question);
                //vm.Reponse.QuestionId = vm.Question.QuestionId;                
                await reponsesService.Create(vm.Reponse);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Reponses/Edit/id
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var question = await questionsService.Get((int)id);
            if (question == null)
            {
                return HttpNotFound();
            }

            var modules = new SelectList(await modulesService.GetAll(), "moduleId", "moduleLib");
            var niveaux = new SelectList(await niveauxService.GetAll(), "niveauId", "niveauLib");

            var vm = new QuestionCreateUpdateVM
            {
                Question = question,
                AvailableModules = modules,
                AvailableNiveaux = niveaux,
                SelectedModuleId = question.Module.ModuleId,
                SelectedNiveauId = question.Niveau.NiveauId
            };

            return View(vm);
        }

        // POST: Reponses/Edit/id
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(QuestionCreateUpdateVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.Question.Module = new ModuleVM { ModuleId = vm.SelectedModuleId };
                vm.Question.Niveau = new NiveauVM { NiveauId = vm.SelectedNiveauId };

                await questionsService.UpdateAsync(vm.Question);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Questions/Delete/id
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var question = await questionsService.Get((int)id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await questionsService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
namespace BabaRh.Web.Controllers
{
    using BabaRh.Web.Models.ViewModel;
    using BabaRh.Web.Services;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class ReponsesController : Controller
    {
       private readonly ReponsesService reponsesService = new ReponsesService();
       private readonly QuestionsService questionsService = new QuestionsService();

        // GET: Reponses/Index
        public async Task<ActionResult> Index()
        {
            var reponses = await reponsesService.GetAll();

            if (reponses == null)
            {
                return HttpNotFound();
            }
            return View(reponses);
        }

        // GET: Reponses/Create
        public ActionResult Create()
        {
           //var questions = new SelectList(await questionsService.GetAll(), "QuestionId", "QuestionLib");
            var vm = new ReponseVM();

            return View(vm);
        }

        // POST: Reponses/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReponseVM vm)
        {
            if (ModelState.IsValid)
            {
                //vm.Reponse.Question = new Question { Id = vm.QuestionId };
                vm.ReponseLib = vm.ReponseLib;
                await reponsesService.Create(vm);
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

            var reponse = await reponsesService.Get((int)id);
            if (reponse == null)
            {
                return HttpNotFound();
            }

            return View(reponse);
        }

        // POST: Reponses/Edit/id
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ReponseVM reponse)
        {
            if (ModelState.IsValid)
            {
                await reponsesService.UpdateAsync(reponse);
                return RedirectToAction("Index");
            }

            return View(reponse);
        }

        // GET: Reponses/Delete/id
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var reponse = await reponsesService.Get((int)id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // POST: Reponses/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await reponsesService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
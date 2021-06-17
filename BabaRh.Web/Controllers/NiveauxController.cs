namespace BabaRh.Web.Controllers
{
    using BabaRh.Web.Models.ViewModel;
    using BabaRh.Web.Services;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class NiveauxController : Controller
    {
        private readonly NiveauxService niveauxService = new NiveauxService();
        

        // GET: Niveaux/Index
        public async Task<ActionResult> Index()

        {
            var niveaux = await niveauxService.GetAll();

            if (niveaux == null)
            {
                return HttpNotFound();
            }

            return View(niveaux);
        }
      

        //GET: Niveaux/Create
        public ActionResult Create()
        {
            var vm = new NiveauVM();

            return View(vm);
        }

        // POST: Niveaux/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NiveauVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.NiveauLib = vm.NiveauLib;

                await niveauxService.Create(vm);
                return RedirectToAction("Index");
            }

            return View(vm);
        }


        // GET: Niveaux/Edit/id
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var niveau = await niveauxService.Get((int)id);
            if (niveau == null)
            {
                return HttpNotFound();
            }


            return View(niveau);

        }

        // POST: Niveaux/Edit/id
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(NiveauVM niveau)
        {
            if (ModelState.IsValid)
            {

                await niveauxService.UpdateAsync(niveau);
                return RedirectToAction("Index");
            }

            return View(niveau);
        }

        // GET: Niveaux/Delete/id
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var niveau = await niveauxService.Get((int)id);
            if (niveau == null)
            {
                return HttpNotFound();
            }
            return View(niveau);
        }

        // POST: Niveaux/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await niveauxService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
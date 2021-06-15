﻿namespace BabaRh.Web.Controllers
{
    using BabaRh.Web.Models.ViewModel;
    using BabaRh.Web.Services;    
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class ModulesController : Controller
    {
        
        private readonly ModulesService modulesService = new ModulesService();

        // GET: Modules/Index
        public async Task<ActionResult> Index()
        
        {
           var listModules = await modulesService.GetAll();

            if (listModules == null)
            {
                return HttpNotFound();
            }

            return View(listModules);
        }
        // GET: Modules/Details/5
        public async Task<ActionResult> Details(int? moduleId)
        {
            if (moduleId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var module = await modulesService.Get((int)moduleId);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }


        //GET: Modules/Create
        public  ActionResult Create()
        {
            var vm = new ModuleVM();

            return View(vm);
        }

        // POST: Modules/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ModuleVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.ModuleLib = vm.ModuleLib;
               
                await modulesService.Create(vm);
                return RedirectToAction("Index");
            }

            return View(vm);
        }


        // GET: Modules/Edit
        public async Task<ActionResult> Edit(int? moduleId)
        {
            if (moduleId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var module = await modulesService.Get((int)moduleId);
            if (module == null)
            {
                return HttpNotFound();
            }
           

            return View(module);
           
        }

        // POST: Modules/Edit
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ModuleVM module)
        {
            if (ModelState.IsValid)
            {
               
                await modulesService.UpdateAsync(module);
                return RedirectToAction("Index");
            }

            return View(module);
        }

        // GET: Modules/Delete/id
        public async Task<ActionResult> Delete(int? moduleId)
        {
            if (moduleId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var module = await modulesService.Get((int)moduleId);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int moduleId)
        {
            await modulesService.Delete(moduleId).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
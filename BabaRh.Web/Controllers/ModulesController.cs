using BabaRh.Web.Models.ViewModel;
using BabaRh.Web.Services;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BabaRh.Web.Controllers
{
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
        // GET: Modules/Details/1
        public async Task<ActionResult> Details(string moduleLib)
        {
            var module = await modulesService.Get(moduleLib);
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
        public async Task<ActionResult> Edit(string moduleLib)
        {
            if (moduleLib == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var module = await modulesService.Get(moduleLib);
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



    }
}
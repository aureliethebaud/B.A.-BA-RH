using BabaRh.Web.Models.ViewModel;
using BabaRh.Web.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BabaRh.Web.Controllers
{
    public class ModulesController : Controller
    {
        
        private readonly ModulesService modulesService = new ModulesService();

        // GET: Modules
        public async Task<ActionResult> Index()
        
        {
           var list = await modulesService.GetAll();

           return View(list);
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
        public async Task<ActionResult> Create(ModuleVM moduleVM)
        {
            if (ModelState.IsValid)
            {
                moduleVM = new ModuleVM();
               
                await modulesService.Create(moduleVM);
                return RedirectToAction("Index");
            }

            return View(moduleVM);
        }
    }
}
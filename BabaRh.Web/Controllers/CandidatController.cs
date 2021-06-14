using BabaRh.Web.Models.ViewModel;
using BabaRh.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
 
namespace BabaRh.Web.Controllers
{
    public class CandidatController : Controller
    {
        private readonly CandidatService candidatService = new CandidatService();

        // GET: Candidat/Idex/
        public async Task<ActionResult> Index()
        {
            var candidats = await candidatService.GetAll();

            if (candidats == null)
            {
                return HttpNotFound();
            }
            return View(candidats);
        }

        // GET: Candidat/Create
        public ActionResult Create()
        {
            var vm = new CandidatVM();

            return View(vm);
        }

        // POST: Candidat/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CandidatVM vm)
        {
            if (ModelState.IsValid)
            {
                vm.Nom = vm.Nom.ToUpper();
                await candidatService.Create(vm);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Candidats/Edit/id
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var candidat = await candidatService.Get((int)id);
            if (candidat == null)
            {
                return HttpNotFound();
            }

            return View(candidat);
        }

        // POST: Candidats/Edit/id
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CandidatVM candidat)
        {
            if (ModelState.IsValid)
            {
                await candidatService.UpdateAsync(candidat);
                return RedirectToAction("Index");
            }

            return View(candidat);
        }
    }
}
﻿using BabaRh.Web.Services;
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
        //private readonly QuestionService questionService = new QuestionService();
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

        // GET: Pizzas/Create
        public async Task<ActionResult> Create()
        {
            var module = (await moduleService.GetAll());
            for (int i = 0; i < module.Count; i++)
            {
                module[i].FakeId = i+1;
            }

            var candidats = new SelectList(await candidatService.GetAll(), "Id", "Nom", "Prenom");
            var modules = new SelectList(await moduleService.GetAll(), "FakeId", "ModuleLib");

            //var questions = new SelectList(await questionService.GetAll(), "Param1", "Param2", "...");

            var vm = new QuizzCreateUpdateVM
            {
                AvailableCandidats = candidats,
                AvailableModules = modules
                //AvailableQuestions = questions
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
                vm.Quizz.Modules = vm.SelectedModulesLibs.Select(l => new ModuleVM { FakeId = l }).ToList();
                //vm.Quizz.Questions = vm.SelectedQuestionsIds.Select(i => new Question { Id = i }).ToList();

                await quizzService.Create(vm.Quizz);
                return RedirectToAction("Index");
            }

            return View(vm);
        }
    }
}
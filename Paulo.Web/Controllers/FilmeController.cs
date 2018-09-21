using AutoMapper;
using Paulo.Core.Services;
using Paulo.Data.Entities;
using Paulo.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Paulo.Web.Controllers
{
    [Authorize]
    public class FilmeController : Controller
    {
        private readonly IFilmeService filmeService;
        private readonly IGeneroService generoService;

        public FilmeController(
            IFilmeService filmeService, 
            IGeneroService generoService
            )
        {
            this.filmeService = filmeService;
            this.generoService = generoService;
        }

        // GET: Filme
        public ActionResult Index()
        {
            var filmeViewModel = Mapper.Map<List<FilmeViewModel>>(filmeService.GetAll());

            return View(filmeViewModel);
        }

        // GET: Filme/Details/5
        public ActionResult Details(int id)
        {
            var filmeViewModel = Mapper.Map<FilmeViewModel>(filmeService.GetById(id));

            return View(filmeViewModel);
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            ViewBag.Generos = new SelectList(
                    generoService.GetAll(),
                    "Id",
                    "Nome"
                );

            return View();
        }

        // POST: Filme/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmeViewModel filmeViewModel)
        {
            if (ModelState.IsValid)
            {
                var filme = Mapper.Map<Filme>(filmeViewModel);
                filmeService.Add(filme);

                return RedirectToAction("Index");
            }

            return View(filmeViewModel);
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int id)
        {
            var filmeViewModel = Mapper.Map<FilmeViewModel>(filmeService.GetById(id));

            ViewBag.Generos = new SelectList(
                    generoService.GetAll(),
                    "Id",
                    "Nome",
                    filmeViewModel.Genero.Id
                );

            return View(filmeViewModel);
        }

        // POST: Filme/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FilmeViewModel filmeViewModel)
        {
            if (ModelState.IsValid)
            {
                var filme = Mapper.Map<Filme>(filmeViewModel);
                filmeService.Update(filme);

                return RedirectToAction("Index");
            }

            return View(filmeViewModel);
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int id)
        {
            var filmeViewModel = Mapper.Map<FilmeViewModel>(filmeService.GetById(id));

            return View(filmeViewModel);
        }

        // POST: Filme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            filmeService.Remove(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMany(List<int> idsToDelete)
        {
            if (ModelState.IsValid)
            {
                filmeService.RemoveMany(idsToDelete);
            }

            return RedirectToAction("Index");
        }
    }
}

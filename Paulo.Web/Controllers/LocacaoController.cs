using AutoMapper;
using Microsoft.AspNet.Identity;
using Paulo.Core.Services;
using Paulo.Data.Entities;
using Paulo.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Paulo.Web.Controllers
{
    [Authorize]
    public class LocacaoController : Controller
    {
        private readonly ILocacaoService locacaoService;
        private readonly IFilmeService filmeService;

        public LocacaoController(
            ILocacaoService locacaoService,
            IFilmeService filmeService)
        {
            this.locacaoService = locacaoService;
            this.filmeService = filmeService;
        }

        // GET: Locacao
        public ActionResult Index()
        {
            var locacaoViewModel = Mapper.Map<List<LocacaoViewModel>>(locacaoService.GetAll());

            return View(locacaoViewModel);
        }

        // GET: Locacao/Details/5
        public ActionResult Details(int id)
        {
            var locacaoViewModel = Mapper.Map<LocacaoViewModel>(locacaoService.GetById(id));

            return View(locacaoViewModel);
        }

        // GET: Locacao/Create
        public ActionResult Create()
        {
            var filmesToSelect = Mapper.Map<List<FilmeViewModel>>(filmeService.GetAllToSelect());

            ViewBag.FilmesToSelect = new SelectList(
                filmesToSelect,
                "Id",
                "Nome"
                );

            return View();
        }

        // POST: Locacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocacaoViewModel locacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var locacao = Mapper.Map<Locacao>(locacaoViewModel);
                locacaoService.RentFilmes(locacao, locacaoViewModel.SelectedFilmesIds, User.Identity.GetUserId<int>());

                return RedirectToAction("Index");
            }

            return View(locacaoViewModel);
        }

        // GET: Locacao/Edit/5
        public ActionResult Edit(int id)
        {
            var locacaoViewModel = Mapper.Map<LocacaoViewModel>(locacaoService.GetById(id));
            var filmesToSelect = Mapper.Map<List<FilmeViewModel>>(filmeService.GetAllToSelect());
            filmesToSelect.AddRange(locacaoViewModel.Filmes);

            ViewBag.SelectedFilmes = new MultiSelectList(
                filmesToSelect.OrderBy(o => o.Nome).ToList(),
                "Id",
                "Nome",
                locacaoViewModel.Filmes.Select(x => x.Id)
                );

            return View(locacaoViewModel);
        }

        // POST: Locacao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocacaoViewModel locacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var locacao = Mapper.Map<Locacao>(locacaoViewModel);
                locacaoService.UpdateRentFilmes(locacao.Id, locacaoViewModel.SelectedFilmesIds);

                return RedirectToAction("Index");
            }

            return View(locacaoViewModel);
        }

        // GET: Locacao/Delete/5
        public ActionResult Delete(int id)
        {
            var locacaoViewModel = Mapper.Map<LocacaoViewModel>(locacaoService.GetById(id));

            return View(locacaoViewModel);
        }

        // POST: Locacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            locacaoService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}

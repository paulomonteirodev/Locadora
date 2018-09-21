using AutoMapper;
using Paulo.Core.Services;
using Paulo.Data.Entities;
using Paulo.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Paulo.Web.Controllers
{
    [Authorize]
    public class GeneroController : Controller
    {
        private readonly IGeneroService generoService;

        public GeneroController(IGeneroService generoAppService)
        {
            this.generoService = generoAppService;
        }

        // GET: Genero
        public ActionResult Index()
        {
            var generoViewModel = Mapper.Map<List<GeneroViewModel>>(generoService.GetAll());

            return View(generoViewModel);
        }

        // GET: Genero/Details/5
        public ActionResult Details(int id)
        {
            var generoViewModel = Mapper.Map<GeneroViewModel>(generoService.GetById(id));

            return View(generoViewModel);
        }

        // GET: Genero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GeneroViewModel generoViewModel)
        {
            if (ModelState.IsValid)
            {
                var genero = Mapper.Map<Genero>(generoViewModel);
                generoService.Add(genero);

                return RedirectToAction("Index");
            }

            return View(generoViewModel);
        }

        // GET: Genero/Edit/5
        public ActionResult Edit(int id)
        {
            var generoViewModel = Mapper.Map<GeneroViewModel>(generoService.GetById(id));

            return View(generoViewModel);
        }

        // POST: Genero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GeneroViewModel generoViewModel)
        {
            if (ModelState.IsValid)
            {
                var genero = Mapper.Map<Genero>(generoViewModel);
                generoService.Update(genero);

                return RedirectToAction("Index");
            }

            return View(generoViewModel);
        }

        // GET: Genero/Delete/5
        public ActionResult Delete(int id)
        {
            var generoViewModel = Mapper.Map<GeneroViewModel>(generoService.GetById(id));

            return View(generoViewModel);
        }

        // POST: Genero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            generoService.Remove(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMany(List<int> idsToDelete)
        {
            if (ModelState.IsValid)
            {
                generoService.RemoveMany(idsToDelete);
            }

            return RedirectToAction("Index");
        }
    }
}

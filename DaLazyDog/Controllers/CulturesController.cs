using System;
using System.Collections.Generic;
using System.Linq;
using Lazydog.Model;
using Lazydog.Model.Repo;
using Lazydog.mysql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DaLazyDog.Controllers
{
    public class CulturesController : Controller
    {
        // GET: Cultures
        public ActionResult Index()
        {
            IDbRepoInstantiator factory = HttpContext.RequestServices.GetService(typeof(IDbRepoInstantiator)) as IDbRepoInstantiator;
            IList<LocalizationCulture> Cultures = factory.GetCultureRepo(Program.AppLogger).GetSupportedCultures();
            return View(Cultures);
        }

        // GET: Cultures/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cultures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cultures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cultures/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cultures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cultures/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cultures/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
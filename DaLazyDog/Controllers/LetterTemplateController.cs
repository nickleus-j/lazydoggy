using System;
using System.Collections.Generic;
using System.Linq;

using DaLazyDog.Models;
using Lazydog.mysql;
using Lazydog.Model;
using Lazydog.Model.Service;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lazydog.Model.Repo;

namespace DaLazyDog.Controllers
{
    public class LetterTemplateController : Controller
    {
        // GET: LetterTemplate
        public ActionResult Index()
        {
            IDbRepoInstantiator factory = HttpContext.RequestServices.GetService(typeof(IDbRepoInstantiator)) as IDbRepoInstantiator;
            ViewBag.Excuses = factory.GetExcuseRepo().GetExcuseTitles();
            return View(factory.GetLetterTemplateRepo().GetLetterTemplates());
        }

        // GET: LetterTemplate/Details/5
        public ActionResult Details(int id)
        {
            IDbRepoInstantiator factory = HttpContext.RequestServices.GetService(typeof(IDbRepoInstantiator)) as IDbRepoInstantiator;
            LetterTemplate template = factory.GetLetterTemplateRepo().GetLetterTemplateInHtmlForm(id);
            ViewBag.Excuse = "Flu";
            return View(template);
        }
        public ActionResult MakeLetter(int id,string excuseName)
        {
            IDbRepoInstantiator factory = HttpContext.RequestServices.GetService(typeof(IDbRepoInstantiator)) as IDbRepoInstantiator;
            LetterTemplate template = factory.GetLetterTemplateRepo().GetLetterTemplateInHtmlForm(id);
            ViewBag.Excuse = excuseName;
            return View(nameof(Details), template);
        }
        // GET: LetterTemplate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LetterTemplate/Create
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

        // GET: LetterTemplate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LetterTemplate/Edit/5
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

        // GET: LetterTemplate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LetterTemplate/Delete/5
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
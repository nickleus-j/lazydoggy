﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DaLazyDog.Controllers
{
    public class ExcuseController : Controller
    {
        // GET: Excuse
        public ActionResult Index()
        {
            return View();
        }

        // GET: Excuse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Excuse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Excuse/Create
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

        // GET: Excuse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Excuse/Edit/5
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

        // GET: Excuse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Excuse/Delete/5
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
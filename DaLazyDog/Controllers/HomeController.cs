using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DaLazyDog.Models;
using Lazydog.mysql;
using Lazydog.Model;
using Microsoft.Extensions.Logging;

namespace DaLazyDog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // 	Qi3chvD?-uWm
        [HttpGet]
        public IActionResult SampleExcuse()
        {
            string[] excuses = new string[]{ "LBM","Flu","Immobilizing Lower back pain","Sore Eyes","Severe rash","Migrane", "Broken toilet at home" };
            Random random = new Random();
            return Content( excuses[random.Next(0, excuses.Length-1)]);
        }
        [HttpGet]
        public IActionResult GetRandomExcuse()
        {
            DbRepoInstantiator factory= HttpContext.RequestServices.GetService(typeof(DbRepoInstantiator)) as DbRepoInstantiator;
            return Content(factory.GetExcuseRepo().GetRandomExcuse());
        }
        [HttpGet]
        public IActionResult GetExcuse()
        {
            DbRepoInstantiator factory = HttpContext.RequestServices.GetService(typeof(DbRepoInstantiator)) as DbRepoInstantiator;
            Excuse givenExcuse = new Excuse();
            try
            {

                givenExcuse = factory.GetExcuseRepo(Program.AppLogger).GetAnExcuse();
            }
            catch (Exception ex) {
       
               
            }
            return Json(givenExcuse);
        }
    }
}

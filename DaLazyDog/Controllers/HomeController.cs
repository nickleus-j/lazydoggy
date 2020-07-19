using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DaLazyDog.Models;
using Lazydog.mysql;
using Lazydog.Model;
using Lazydog.Model.Service;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using Lazydog.Model.Repo;

namespace DaLazyDog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        ILoggerFactory _loggerFactory;
        public HomeController(IStringLocalizer<HomeController> localizer, ILoggerFactory loggerFactory)
        {
            _localizer = localizer;
            _loggerFactory = loggerFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            _loggerFactory.CreateLogger("LoggerCategory").LogInformation("Read privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _loggerFactory.CreateLogger("LoggerCategory").LogError(String.Concat("Error ",HttpContext.TraceIdentifier));
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // 	Qi3chvD?-uWm
        
        [HttpGet]
        public IActionResult GetRandomExcuse()
        {
            IDbRepoInstantiator factory= HttpContext.RequestServices.GetService(typeof(IDbRepoInstantiator)) as IDbRepoInstantiator;
            return Content(factory.GetExcuseRepo().GetRandomExcuse());
        }
        [HttpGet]
        public IActionResult GetExcuse()
        {
            IDbRepoInstantiator factory = HttpContext.RequestServices.GetService(typeof(IDbRepoInstantiator)) as IDbRepoInstantiator;
            Excuse givenExcuse = new Excuse();
            try
            { 
                givenExcuse = factory.GetExcuseRepo(Program.AppLogger).GetAnExcuse();
            }
            catch (Exception) { 
            }
            return Json(givenExcuse);
        }
        /// <summary>
        /// Letter generation
        /// </summary>
        /// <returns></returns>
        public IActionResult Letter()
        {
            ExcuseMsgTemplateService msgService = new ExcuseMsgTemplateService();
            ViewBag.Message = msgService.GenerateHtmlOfTemplate(msgService.GenerateSampleLetter());
            return View();
        }
        public IActionResult Color()
        {
            return View();
        }
        public IActionResult Meet()
        {
            return View();
        }
    }
}

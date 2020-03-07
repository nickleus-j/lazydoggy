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

namespace DaLazyDog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }
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
        public IActionResult Letter()
        {
            ExcuseMsgTemplateService msgService = new ExcuseMsgTemplateService();
            ViewBag.Message = msgService.GenerateHtmlOfTemplate(msgService.GenerateSampleLetter());
            return View();
        }
        /*
         * Regex regexElements = new Regex(@"\b(E|Elm|Elem)\b", RegexOptions.IgnoreCase);

            foreach(Match m in regexElements.Matches(str))
            {
                 MessageBox.Show("Match: " + m.Value);
            }

            str = regexElements.Replace(str, "Element"); //str is my string
         * */
    }
}

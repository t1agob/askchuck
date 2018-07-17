using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using askchuck.web.Models;

namespace chuck.web.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            ViewBag.Fact = "Just ask Chuck!";

            return View();
        }

        public async Task<IActionResult> RandomFact()
        {
            HttpResponseMessage response = await client.GetAsync("http://chuckapi/api/quotes");
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Fact = await response.Content.ReadAsStringAsync();
            }



            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
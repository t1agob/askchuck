using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using askchuck.web.Models;
using System.Text;

namespace chuck.web.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        static List<FactCategory> FactCategories;

        public IActionResult Index()
        {
            ViewBag.Fact = "Just ask Chuck!";

            CreateFactCategories();

            FactCategoryList objBind = new FactCategoryList();
            objBind.FactCategories = FactCategories;
            return View(objBind);
        }

        [HttpPost]
        public async Task<ActionResult> Index(FactCategoryList Obj)
        {
            string url = (Obj.SelectedCategory == "none" || Obj.SelectedCategory == null) ? $"http://askchuckapi/api/quotes" : $"http://askchuckapi/api/quotes?category={Obj.SelectedCategory}";
            
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Fact = await response.Content.ReadAsStringAsync();
            }

            FactCategoryList objBind = new FactCategoryList();
            objBind.FactCategories = FactCategories;
            objBind.SelectedCategory = Obj.SelectedCategory;
            return View(objBind);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void CreateFactCategories()
        {
            if(FactCategories == null)
            {
                FactCategories = new List<FactCategory>()
                {
                    new FactCategory{ Text = "None", Category = "none", ButtonStyle = "default" },
                    new FactCategory{ Text = "Geek", Category = "dev", ButtonStyle = "danger" },
                    new FactCategory{ Text = "Science", Category = "science", ButtonStyle = "warning" },
                    new FactCategory{ Text = "Sports", Category = "sport", ButtonStyle = "info" },
                    new FactCategory{ Text = "Movies", Category = "movies", ButtonStyle = "success" },
                    new FactCategory{ Text = "History", Category = "history", ButtonStyle = "primary" }
                };
            }            
        }
    }
}
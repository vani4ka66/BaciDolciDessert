using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaciDolci.App.Services;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Data;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Home;
using BaciDolci.Models.ViewModels.Product;

namespace BaciDolci.App.Controllers
{
    [RoutePrefix("home")]
    //[MyAuthoize(Roles = "Admin, Customer")]
    public class HomeController : Controller
    {
        private IHomeService service;

        public HomeController()
        {
        }

        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("carousel")]
        [AllowAnonymous]
        public ActionResult Carousel()
        {
            return View();
        }

        [HttpGet]
        [Route("news")]
        [AllowAnonymous]
        public ActionResult News()
        {
            IEnumerable<NewsItemViewModel> view = this.service.GetAllNews();

            ViewBag.MaxPages = this.service.GetMaxPapes();
            ViewBag.CurrentPage = this.service.GetCurrentPage();

            return View(view);
        }


        [HttpGet]
        [Route("about")]
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        [Route("contact")]
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        [Route("index")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var products = this.service.GetAllProducts();

            return View(products);
        }

        [HttpPost]
        [Route("search")]
        [AllowAnonymous]
        public PartialViewResult Search(string keyword)
        {
            IEnumerable<Product> products = this.service.SearchProduct(keyword);

            return this.PartialView("_SearchPartial", products);
        }

    }
}
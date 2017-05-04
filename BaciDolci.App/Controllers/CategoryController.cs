using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaciDolci.App.Services;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.ViewModels.Product;

namespace BaciDolci.App.Controllers
{
    [RoutePrefix("category")]
    public class CategoryController : Controller
    {
        private ICategoryService service;

        public CategoryController()
        {
        }

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("allcategories")]
        [AllowAnonymous]
        public ActionResult AllCategories()
        {
            IEnumerable<CategoryViewModel> view = this.service.GetAllCategoriesNamesImages();

            return this.View(view);
        }

        [HttpGet]
        [Route("detailcategory/{id}")]
        [AllowAnonymous]
        public ActionResult DetailCategory(int Id)
        {
            IEnumerable<ProductViewModel> view = this.service.GetDetailCategory(Id);

            return View(view);
        }
    }
}
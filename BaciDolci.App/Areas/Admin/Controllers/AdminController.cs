using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BaciDolci.App.Areas.Admin.Services;
using BaciDolci.App.Attributes;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.BindingModels;
using BaciDolci.Models.ViewModels.Product;
using Microsoft.AspNet.Identity.Owin;

namespace BaciDolci.App.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [RoutePrefix("admin")]
    [MyAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IAdminService service;
        private ApplicationUserManager _userManager;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }

        public AdminController()
        {
            
        }

        public AdminController(ApplicationUserManager usermanager) : this()
        {
            this.UserManager = usermanager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        [HttpGet]
        [Route("addcategory")]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("addcategory")]
        public ActionResult AddCategory(CategoryBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                this.service.GetAddCategory(bind);

                return RedirectToAction("AllCategories", "Category", new { area = "" });
            }

            return this.View();

        }

        [HttpGet]
        [Route("editcategory/{id}")]
        public ActionResult EditCategory(int id)
        {
            CategoryBindingModel view = this.service.GetEditCategory(id);

            return this.View(view);
        }

        [HttpPost]
        [Route("editcategory/{id}")]
        public ActionResult EditCategory([Bind(Include = "Id, Name, Image")] CategoryBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                this.service.UpdateCategory(bind);

                return RedirectToAction("AllCategories", "Category", new {area = ""});
            }

            return this.View(bind);
        }

        [HttpGet]
        [Route("deletecategory/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            DeleteCategoryBindingModel view = this.service.GetDeleteCategory(id);

            return this.View(view);
        }

        [HttpPost]
        [Route("deletecategory/{id}")]
        public ActionResult DeleteCategory([Bind(Include = "Id, Name")] DeleteCategoryBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                this.service.DeleteCategory(bind);

                return RedirectToAction("AllCategories", "Category", new {area = ""});
            }

            return this.View(bind);
        }

        [HttpGet]
        [Route("addproduct")]
        public ActionResult AddProduct()
        {
            ViewBag.CategoriesNames = this.service.GetAllCategoriesId();

            return View();
        }

        [HttpPost]
        [Route("addproduct")]
        public ActionResult AddProduct(ProductBindingModel bind)
        {
            //if (ModelState.IsValid)
            //{
                this.service.GetAddProduct(bind);

                return RedirectToAction("AllCategories", "Category", new {area = ""});
            //}

            //return this.View();
        }

        [HttpGet]
        [Route("editproduct/{id}")]
        public ActionResult EditProduct(int id)
        {
            ProductBindingModel view = this.service.GetEditProduct(id);

            ViewBag.Categoriess = this.service.GetAllCategoriesId();

            return this.View(view);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("editproduct/{id}")]
        public ActionResult EditProduct([Bind(Include = "Id, Name, Image, Price, CategoryId")] ProductBindingModel bind)
        {
            //if (ModelState.IsValid)
            //{
                this.service.UpdateProduct(bind);

                return RedirectToAction("AllCategories", "Category", new {area = ""});
            //}

            //return this.View(bind);
        }

        [HttpGet]
        [Route("deleteproduct/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            DeleteProductBindingModel view = this.service.GetDeleteProduct(id);

            return this.View(view);
        }

        [HttpPost]
        [Route("deleteproduct/{id}")]
        public ActionResult DeleteProduct([Bind(Include = "Id, Name")] DeleteProductBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                this.service.DeleteProduct(bind);

                return RedirectToAction("AllCategories", "Category", new {area = ""});
            }

            return this.View(bind);
        }

        [HttpGet]
        [Route("addnews")]
        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [Route("addnews")]
        public ActionResult AddNews(NewsBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                this.service.GetAddNews(bind);

                return RedirectToAction("News", "Home", new {area = ""});
            }

            return this.View();
        }

        [HttpGet]
        [Route("editnews/{id}")]
        public ActionResult EditNews(int id)
        {
            NewsBindingModel view = this.service.GetEditNews(id);

            return this.View(view);
        }

        [HttpPost]
        [Route("editnews/{id}")]
        public ActionResult EditNews(NewsBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                this.service.UpdateNews(bind);

                return RedirectToAction("News", "Home", new {area = ""});
            }

            return this.View(bind);
        }

        [HttpGet]
        [Route("deletenews/{id}")]
        public ActionResult DeleteNews(int id)
        {
            DeleteNewsBindingModel view = this.service.GetDeleteNews(id);

            return this.View(view);
        }

        [HttpPost]
        [Route("deletenews/{id}")]
        public ActionResult DeleteNews([Bind(Include = "Id, Name")] DeleteNewsBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                this.service.DeleteNews(bind);

                return RedirectToAction("News", "Home", new {area = ""});
            }

            return this.View(bind);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaciDolci.App.Attributes;
using BaciDolci.App.Services;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.BindingModels;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Product;
using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;

namespace BaciDolci.App.Controllers
{
    [RoutePrefix("product")]
    //[MyAuthorize(Roles = "Admin, Customer")]
    public class ProductController : Controller
    {
        private IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("detailproduct/{id}")]
        [AllowAnonymous]
        public ActionResult DetailProduct(int Id)
        {
            ProductViewModel view = this.service.GetDetailProduct(Id);

            return View(view);
        }

        [HttpPost]
        [Route("buy/{id}")]
        [MyAuthorize(Roles = "Customer")]
        public ActionResult Buy(BuyProductBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                var user = this.User.Identity.GetUserName();
                this.service.BuyProduct(user, bind);

                return RedirectToAction("MyProfile", "Customer", new {area = ""});
            }

            return this.View("DetailProduct");
        }
    }
}
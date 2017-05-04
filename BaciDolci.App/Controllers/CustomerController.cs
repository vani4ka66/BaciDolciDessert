using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaciDolci.App.Attributes;
using BaciDolci.App.Services;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Customer;
using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;

namespace BaciDolci.App.Controllers
{
    [RoutePrefix("customer")]
    //[MyAuthorize(Roles = "Admin, Customer")]
    public class CustomerController : Controller
    {
        private ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("myprofile")]
        [MyAuthorize(Roles = "Customer")]
        public ActionResult MyProfile()
        {
            string user = this.User.Identity.GetUserName();
            CustomerProfileViewModel view = this.service.GetMyProfile(user);

            return View(view);
        }

        [HttpGet]
        [Route("allcustomers")]
        [MyAuthorize(Roles = "Admin")]
        public ActionResult AllCustomers()
        {
            IEnumerable<Customer> customers = this.service.GetCustomers();

            return View(customers);
        }
    }
}
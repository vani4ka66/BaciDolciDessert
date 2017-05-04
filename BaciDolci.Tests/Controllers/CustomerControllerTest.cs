using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BaciDolci.App.Controllers;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.EntityModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BaciDolci.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void AllCustomers_NotNull()
        {
            var mock = new Mock<ICustomerService>();

            List<Customer> customers = new List<Customer>();

            var customer1 = new Customer()
            {
                Id = 100,
                FullName = "Ivan Ivanov",
                Email = "ivan@abv.bg",
                UserName = "ivan@abv.bg"
            };

            var customer2 = new Customer()
            {
                Id = 101,
                FullName = "Gosho Goshev",
                Email = "gosho@abv.bg",
                UserName = "gosho@abv.bg"
            };

            customers.Add(customer1);
            customers.Add(customer2);

            mock.Setup(m => m.GetCustomers())
                .Returns(customers);

            var controller = new CustomerController(mock.Object);

            var result = controller.AllCustomers() as ViewResult;

            Assert.IsNotNull(result);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BaciDolci.App.Controllers;
using BaciDolci.App.Services;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Home;
using BaciDolci.Models.ViewModels.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;
using Moq;


namespace BaciDolci.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        //private ProductController _controller;

        [TestMethod]
        public void DetailProduct_NotNull()
        {
            var mock = new Mock<IProductService>();

            //ProductViewModel product = new ProductViewModel();

            var product1 = new ProductViewModel()
            {
                Id = 100,
                Name = "4rd",
                Image = "../../Content/imajes/32.png",
                Price = 6,
                CategoryId = 5
            };

            mock.Setup(m => m.GetDetailProduct(product1.Id))
                .Returns(product1);

            var controller = new ProductController(mock.Object);

            var result = controller.DetailProduct(product1.Id) as ViewResult;

            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void Buy_Redirect()
        //{
            
        //}
    }
}

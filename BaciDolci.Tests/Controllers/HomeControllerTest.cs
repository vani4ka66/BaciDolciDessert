using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BaciDolci.App.Areas.Admin.Controllers;
using BaciDolci.App.Controllers;
using BaciDolci.App.Services;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;
using Moq;

namespace BaciDolci.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController _controller;

        [TestInitialize]
        public void Init()
        {
            this._controller = new HomeController();
        }


        [TestMethod]
        public void About_NotNull()
        {
            //ViewResult result = controller.About() as ViewResult;
            //Assert.IsNotNull(result);

            _controller.WithCallTo(x => x.About()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Carousell_NotNull()
        {
            _controller.WithCallTo(x => x.Carousel()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Contacts_NotNull()
        {
            _controller.WithCallTo(x => x.Contact()).ShouldRenderDefaultView();

        }

        [TestMethod]
        public void News_NotNull()
        {
            var mock = new Mock<IHomeService>();

            List<NewsItemViewModel> news = new List<NewsItemViewModel>();

            var newsItem = new NewsItemViewModel()
            {
                Id = 100,
                Name = "4rd",
                Image = "../../Content/imajes/32.png"
            };

            var newsItem2 = new NewsItemViewModel()
            {
                Id = 101,
                Name = "4ng",
                Image = "../../Content/imajes/34.png"
            };

            news.Add(newsItem);
            news.Add(newsItem2);

            mock.Setup(m => m.GetAllNews(1, 5))
                .Returns(news);   

            var controller = new HomeController(mock.Object);

            var result = controller.News() as ViewResult;

            Assert.IsNotNull(result);

           // _controller.WithCallTo(c => c.News()).ShouldRenderDefaultView().WithModel<IEnumerable<NewsItemViewModel>>(news);

        }

        [TestMethod]
        public void Index_NotNull()
        {
            var mock = new Mock<IHomeService>();

            List<Product> products = new List<Product>();

            var product1 = new Product()
            {
                Id = 100,
                Name = "4rd",
                Image = "../../Content/imajes/32.png",
                Price = 6,
                CategoryId = 5
            };

            var product2 = new Product()
            {
                Id = 101,
                Name = "4ng",
                Image = "../../Content/imajes/34.png",
                Price = 8,
                CategoryId = 10
            };

            products.Add(product1);
            products.Add(product2);

            mock.Setup(m => m.GetAllProducts())
                .Returns(products);

            var controller = new HomeController(mock.Object);

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Search_PartialView()
        {
            var mock = new Mock<IHomeService>();

            List<Product> products = new List<Product>();

            var product1 = new Product()
            {
                Id = 10,
                Name = "pasta",
                Image = "../../Content/images/34.png",
                Price = 5,
                CategoryId = 6
            };

            var product2 = new Product()
            {
                Id = 11,
                Name = "torta",
                Image = "../../Content/images/32.png",
                Price = 5,
                CategoryId = 6
            };

            products.Add(product1);
            products.Add(product2);

            string keyword = "torta";

            mock.Setup(m => m.SearchProduct(keyword));

            var controller = new HomeController(mock.Object);

            var result = controller.Search(keyword) as PartialViewResult;

            controller.WithCallTo(c => c.Search(keyword)).ShouldRenderPartialView("_SearchPartial");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BaciDolci.App.Controllers;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BaciDolci.Tests.Controllers
{
    [TestClass]
    public class CategoryControllerTest
    {
        [TestMethod]
        public void AllCategories_NotNull()
        {
            var mock = new Mock<ICategoryService>();

            List<CategoryViewModel> categories = new List<CategoryViewModel>();

            var category1 = new CategoryViewModel()
            {
                Id = 100,
                Name = "Palachinki",
                Image = "../../Content/images/32.png"
            };

            var category2 = new CategoryViewModel()
            {
                Id = 101,
                Name = "Lokum",
                Image = "../../Content/images/32.png"
            };

            categories.Add(category1);
            categories.Add(category2);

            mock.Setup(m => m.GetAllCategoriesNamesImages())
                .Returns(categories);

            var controller = new CategoryController(mock.Object);

            var result = controller.AllCategories() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailCategory_NotNull()
        {
            var mock = new Mock<ICategoryService>();

            List<ProductViewModel> products = new List<ProductViewModel>();

            var product1 = new ProductViewModel()
            {
                Id = 100,
                Name = "4rd",
                Image = "../../Content/imajes/32.png",
                Price = 1,
                CategoryId = 8
            };

            var product2 = new ProductViewModel()
            {
                Id = 101,
                Name = "4ng",
                Image = "../../Content/imajes/34.png",
                Price = 6,
                CategoryId = 5
            };

            products.Add(product1);
            products.Add(product2);


            mock.Setup(m => m.GetDetailCategory(product1.CategoryId))
                .Returns(products);

            var controller = new CategoryController(mock.Object);

            var result = controller.DetailCategory(product1.CategoryId) as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}

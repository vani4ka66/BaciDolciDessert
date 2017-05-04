using System;
using BaciDolci.App.Areas.Admin.Controllers;
using BaciDolci.App.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BaciDolci.App.Services;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.BindingModels;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Home;
using BaciDolci.Models.ViewModels.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;
using Moq;

namespace BaciDolci.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        private AdminController _controller;

        [TestInitialize]
        public void Init()
        {
            this._controller = new AdminController();
        }

        [TestMethod]
        public void AddCategory_Get_NotNull()
        {
            _controller.WithCallTo(x => x.AddCategory()).ShouldRenderDefaultView();

        }

        [TestMethod]
        public void AddCategory_Post_Redirect()
        {
            var mock = new Mock<IAdminService>();

            var category = new CategoryBindingModel()
            {
                Id = 10,
                Name = "pasta",
                Image = "../../Content/images/34.png"
            };

            mock.Setup(m => m.GetAddCategory(category));

            var controller = new AdminController(mock.Object);

            var result = controller.AddCategory(category) as RedirectToRouteResult;

            controller.WithCallTo(c => c.AddCategory(category))
                  .ShouldRedirectTo<CategoryController>(typeof(CategoryController).GetMethod("AllCategories"));
        }

        //[TestMethod]
        //public void AddProduct_Get_NotNull()
        //{
          //  _controller.WithCallTo(x => x.AddProduct()).ShouldRenderDefaultView();
        //}

        [TestMethod]
        public void AddProduct_Post_Redirect()
        {
            var mock = new Mock<IAdminService>();

            var product = new ProductBindingModel()
            {
                Id = 10,
                Name = "pasta",
                Image = "../../Content/images/34.png",
                Price = 5,
                CategoryId = 6
            };

            mock.Setup(m => m.GetAddProduct(product));

            var controller = new AdminController(mock.Object);

            var result = controller.AddProduct(product) as RedirectToRouteResult;

            controller.WithCallTo(c => c.AddProduct(product))
                  .ShouldRedirectTo<CategoryController>(typeof(CategoryController).GetMethod("AllCategories"));
        }

        [TestMethod]
        public void AddNews_Get_NotNull()
        {
            _controller.WithCallTo(x => x.AddNews()).ShouldRenderDefaultView();

        }

        [TestMethod]
        public void AddNews_Post_Redirect()
        {
            var mock = new Mock<IAdminService>();

            var news = new NewsBindingModel()
            {
                Id = 10,
                Name = "pasta",
                Image = "../../Content/images/34.png",
                Content = "Neshto drugo"
            };

            mock.Setup(m => m.GetAddNews(news));

            var controller = new AdminController(mock.Object);

            var result = controller.AddNews(news) as RedirectToRouteResult;

            controller.WithCallTo(c => c.AddNews(news))
                  .ShouldRedirectTo<HomeController>(typeof(HomeController).GetMethod("News"));
        }

        [TestMethod]
        public void EditCategory_Get_NotNull()
        {
            var mock = new Mock<IAdminService>();

            var category = new CategoryBindingModel()
            {
                Id = 10,
                Name = "4rd",
                Image = "../../Content/imajes/32.png",
            };

            mock.Setup(m => m.GetEditCategory(category.Id))
                .Returns(category);

            var controller = new AdminController(mock.Object);

            var result = controller.EditCategory(category.Id) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditCategory_Post_Redirect()
        {
            var mock = new Mock<IAdminService>();

            var category = new CategoryBindingModel()
            {
                Id = 10,
                Name = "pasta",
                Image = "../../Content/images/34.png",
            };

            mock.Setup(m => m.UpdateCategory(category));

            var controller = new AdminController(mock.Object);

            var result = controller.EditCategory(category) as RedirectToRouteResult;

            controller.WithCallTo(c => c.EditCategory(category))
                  .ShouldRedirectTo<CategoryController>(typeof(CategoryController).GetMethod("AllCategories"));
        }

        [TestMethod]
        public void DeleteCategory_Get_NotNull()
        {
            var mock = new Mock<IAdminService>();

            var category = new DeleteCategoryBindingModel()
            {
                Id = 10,
                Name = "4rd",
            };

            mock.Setup(m => m.GetDeleteCategory(category.Id))
                .Returns(category);

            var controller = new AdminController(mock.Object);

            var result = controller.DeleteCategory(category.Id) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteCategory_Post_Redirect()
        {
            var mock = new Mock<IAdminService>();

            var category = new DeleteCategoryBindingModel()
            {
                Id = 10,
                Name = "pasta"
            };

            mock.Setup(m => m.DeleteCategory(category));

            var controller = new AdminController(mock.Object);

            var result = controller.DeleteCategory(category.Id) as RedirectToRouteResult;

            controller.WithCallTo(c => c.DeleteCategory(category))
                  .ShouldRedirectTo<CategoryController>(typeof(CategoryController).GetMethod("AllCategories"));
        }

        [TestMethod]
        public void EditProduct_Get_NotNull()
        {
            var mock = new Mock<IAdminService>();

            var product = new ProductBindingModel()
            {
                Id = 100,
                Name = "lokum",
                Image = "../../Content/imajes/32.png",
                Price = 5,
                CategoryId = 6
            };

            mock.Setup(m => m.GetEditProduct(product.Id))
                .Returns(product);

            var controller = new AdminController(mock.Object);

            var result = controller.EditProduct(product.Id) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditProduct_Post_Redirect()
        {
            var mock = new Mock<IAdminService>();

            var product = new ProductBindingModel()
            {
                Id = 10,
                Name = "pasta",
                Image = "../../Content/images/34.png",
                Price = 6,
                CategoryId = 5
            };

            mock.Setup(m => m.UpdateProduct(product));

            var controller = new AdminController(mock.Object);

            var result = controller.EditProduct(product) as RedirectToRouteResult;

            controller.WithCallTo(c => c.EditProduct(product))
                  .ShouldRedirectTo<CategoryController>(typeof(CategoryController).GetMethod("AllCategories"));
        }

        [TestMethod]
        public void DeleteProduct_Get_NotNull()
        {
            var mock = new Mock<IAdminService>();

            var product = new DeleteProductBindingModel()
            {
                Id = 10,
                Name = "lokum",
            };

            mock.Setup(m => m.GetDeleteProduct(product.Id))
                .Returns(product);

            var controller = new AdminController(mock.Object);

            var result = controller.DeleteProduct(product.Id) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteProduct_Post_Redirect()
        {
            var mock = new Mock<IAdminService>();

            var product = new DeleteProductBindingModel()
            {
                Id = 10,
                Name = "pasta"
            };

            mock.Setup(m => m.DeleteProduct(product));

            var controller = new AdminController(mock.Object);

            var result = controller.DeleteProduct(product.Id) as RedirectToRouteResult;

            controller.WithCallTo(c => c.DeleteProduct(product))
                  .ShouldRedirectTo<CategoryController>(typeof(CategoryController).GetMethod("AllCategories"));
        }

        [TestMethod]
        public void EditNews_Get_NotNull()
        {
            var mock = new Mock<IAdminService>();

            var news = new NewsBindingModel()
            {
                Id = 10,
                Name = "4rd",
                Image = "../../Content/imajes/32.png",
                Content = "Za mnogo godini"
            };

            mock.Setup(m => m.GetEditNews(news.Id))
                .Returns(news);

            var controller = new AdminController(mock.Object);

            var result = controller.EditNews(news.Id) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditNews_Post_Redirect()
        {
            var mock = new Mock<IAdminService>();

            var news = new NewsBindingModel()
            {
                Id = 10,
                Name = "pasta",
                Image = "../../Content/images/34.png",
                Content = "Neshto drugo"
            };

            mock.Setup(m => m.UpdateNews(news));

            var controller = new AdminController(mock.Object);

            var result = controller.EditNews(news) as RedirectToRouteResult;

            controller.WithCallTo(c => c.EditNews(news))
                  .ShouldRedirectTo<HomeController>(typeof(HomeController).GetMethod("News"));
        }

        [TestMethod]
        public void DeleteNews_Get_NotNull()
        {
            var mock = new Mock<IAdminService>();

            var news = new DeleteNewsBindingModel()
            {
                Id = 10,
                Name = "4rd"
            };

            mock.Setup(m => m.GetDeleteNews(news.Id))
                .Returns(news);

            var controller = new AdminController(mock.Object);

            var result = controller.DeleteNews(news.Id) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteNews_Post_Redirect()
        {
            var mock = new Mock<IAdminService>();

            var news = new DeleteNewsBindingModel()
            {
                Id = 10,
                Name = "pasta"
            };

            mock.Setup(m => m.DeleteNews(news));

            var controller = new AdminController(mock.Object);

            var result = controller.DeleteNews(news.Id) as RedirectToRouteResult;

            controller.WithCallTo(c => c.DeleteNews(news))
                  .ShouldRedirectTo<HomeController>(typeof(HomeController).GetMethod("News"));
        }
    }
}

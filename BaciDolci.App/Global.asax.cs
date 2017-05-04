using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using BaciDolci.Models.BindingModels;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Account;
using BaciDolci.Models.ViewModels.Customer;
using BaciDolci.Models.ViewModels.Home;
using BaciDolci.Models.ViewModels.Product;

namespace BaciDolci.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.ConfigureMapper();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<RegisterViewModel, Customer>();
                expression.CreateMap<Category, CategoryViewModel>();
                expression.CreateMap<ApplicationUser, CustomerProfileViewModel>();
                expression.CreateMap<Product, ProductViewModel>();
                expression.CreateMap<ProductViewModel, Product>();
                expression.CreateMap<CategoryBindingModel, Category>();
                expression.CreateMap<Category, CategoryBindingModel>();
                expression.CreateMap<DeleteCategoryBindingModel, Category>();
                expression.CreateMap<Category, DeleteCategoryBindingModel>();
                expression.CreateMap<ProductBindingModel, Product>();
                expression.CreateMap<Product, ProductBindingModel>();
                expression.CreateMap<DeleteProductBindingModel, Product>();
                expression.CreateMap<Product, DeleteProductBindingModel>();
                expression.CreateMap<ProductBindingModel, ProductViewModel>();
                expression.CreateMap<Customer, CustomerProfileViewModel>();
                expression.CreateMap<ApplicationUser, CustomerProfileViewModel>();
                expression.CreateMap<ApplicationUser, Customer>();
                expression.CreateMap<NewsItem, NewsItemViewModel>();
                expression.CreateMap<NewsBindingModel ,NewsItem>();
                expression.CreateMap<NewsItem, NewsBindingModel>();
                expression.CreateMap<DeleteNewsBindingModel, NewsItem>();
                expression.CreateMap<NewsItem, DeleteNewsBindingModel>();
                expression.CreateMap<BuyProductBindingModel, Product>();












            });
        }
    }
}

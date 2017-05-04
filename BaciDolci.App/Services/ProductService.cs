using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using AutoMapper;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.BindingModels;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Product;
using Microsoft.AspNet.Identity;
using BaciDolci.Models.ViewModels.Account;
using BaciDolci.Models.ViewModels.Customer;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.VisualBasic.ApplicationServices;


namespace BaciDolci.App.Services
{
    public class ProductService : Service, IProductService
    {
        public ProductViewModel GetDetailProduct(int productId)
        {
            Product product = this.Context.Products.Find(productId);

            ProductViewModel view =
                Mapper.Map<Product, ProductViewModel>(product);


            return view;
        }

        public void BuyProduct(string user, BuyProductBindingModel bind)
        {
            Product originalProduct = this.Context.Products.Find(bind.Id);
            Mapper.Instance.Map<BuyProductBindingModel, Product>(bind);

            Customer customer = this.Context.Customers.FirstOrDefault(x => x.User.UserName == user);

            customer.Products.Add(originalProduct);
            this.Context.SaveChanges();

        }

    }
}
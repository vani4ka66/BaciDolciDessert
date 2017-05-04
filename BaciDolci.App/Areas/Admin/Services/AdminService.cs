using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BaciDolci.App.Services;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.BindingModels;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Product;

namespace BaciDolci.App.Areas.Admin.Services
{
    public class AdminService : Service, IAdminService
    {
        public void GetAddCategory(CategoryBindingModel bind)
        {
            Category category = Mapper.Instance.Map<CategoryBindingModel, Category>(bind);

            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }

        public CategoryBindingModel GetEditCategory(int id)
        {
            Category category = this.Context.Categories.Find(id);

            return Mapper.Instance.Map<Category, CategoryBindingModel>(category);
        }

        public void UpdateCategory(CategoryBindingModel bind)
        {
            Category originalCategory = this.Context.Categories.Find(bind.Id);
            Mapper.Instance.Map<CategoryBindingModel, Category>(bind);

            originalCategory.Name = bind.Name;
            originalCategory.Image = bind.Image;

            this.Context.Entry(originalCategory).State = EntityState.Modified;
            this.Context.SaveChanges();

        }

        public DeleteCategoryBindingModel GetDeleteCategory(int id)
        {
            return Mapper.Instance.Map<Category, DeleteCategoryBindingModel>(Context.Categories.Find(id));
        }

        public void DeleteCategory(DeleteCategoryBindingModel bind)
        {
            Category original = this.Context.Categories.Find(bind.Id);

            Mapper.Instance.Map<DeleteCategoryBindingModel, Category>(bind);

            this.Context.Categories.Remove(original);


            this.Context.SaveChanges();

        }

        public void GetAddProduct(ProductBindingModel bind)
        {
            Product product = Mapper.Instance.Map<ProductBindingModel, Product>(bind);

            product.CategoryId = bind.CategoryId;
            //
            Category category = this.Context.Categories.Find(bind.CategoryId);
            
            category.Products.Add(product);
            //
            this.Context.Products.Add(product);
            this.Context.SaveChanges();

            //Product product = Mapper.Instance.Map<ProductBindingModel, Product>(bind);

            //Category category = this.Context.Categories.Find(bind.CategoryId);
            //category.Products.Add(product);

            //this.Context.SaveChanges();
        }

        public ProductBindingModel GetEditProduct(int id)
        {
            return Mapper.Instance.Map<Product, ProductBindingModel>(Context.Products.Find(id));
        }

        public void UpdateProduct(ProductBindingModel bind)
        {
            Product originalProduct = this.Context.Products.Find(bind.Id);

            originalProduct.Name = bind.Name;
            originalProduct.Image = bind.Image;
            originalProduct.Price = bind.Price;
            originalProduct.CategoryId = this.Context.Categories.Find(bind.CategoryId).Id;


            originalProduct = Mapper.Instance.Map<ProductBindingModel, Product>(bind);

            // this.Context.Products.Attach(productFromDb);
            //this.Context.Entry(originalProduct).State = EntityState.Modified;
            this.Context.SaveChanges();

        }

        public DeleteProductBindingModel GetDeleteProduct(int id)
        {
            return Mapper.Instance.Map<Product, DeleteProductBindingModel>(Context.Products.Find(id));
        }

        public void DeleteProduct(DeleteProductBindingModel bind)
        {

            Product original = this.Context.Products.Find(bind.Id);

            Mapper.Instance.Map<DeleteProductBindingModel, Product>(bind);

            this.Context.Products.Remove(original);

            this.Context.SaveChanges();
        }

        public object GetViewBagCategories()
        {

            return this.Context.Categories.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            });
        }

        public void GetAddNews(NewsBindingModel bind)
        {
            NewsItem news = Mapper.Instance.Map<NewsBindingModel, NewsItem>(bind);

            this.Context.NewsItems.Add(news);
            this.Context.SaveChanges();

        }

        public NewsBindingModel GetEditNews(int id)
        {
            return Mapper.Instance.Map<NewsItem, NewsBindingModel>(Context.NewsItems.Find(id));


        }

        public void UpdateNews(NewsBindingModel bind)
        {
            NewsItem originalNews = this.Context.NewsItems.Find(bind.Id);
            Mapper.Instance.Map<NewsBindingModel, NewsItem>(bind);

            originalNews.Name = bind.Name;
            originalNews.Content = bind.Content;
            originalNews.Image = bind.Image;

            this.Context.Entry(originalNews).State = EntityState.Modified;
            this.Context.SaveChanges();

        }

        public DeleteNewsBindingModel GetDeleteNews(int id)
        {
            return Mapper.Instance.Map<NewsItem, DeleteNewsBindingModel>(Context.NewsItems.Find(id));
        }

        public void DeleteNews(DeleteNewsBindingModel bind)
        {
            NewsItem original = this.Context.NewsItems.Find(bind.Id);

            Mapper.Instance.Map<DeleteNewsBindingModel, NewsItem>(bind);

            this.Context.NewsItems.Remove(original);
            this.Context.SaveChanges();

        }

        public object GetAllCategoriesId()
        {
            return this.Context.Categories.Select(x=> new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                //Selected = categoryId ==x.Id

            }).ToList();
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Product;

namespace BaciDolci.App.Services
{
    public class CategoryService : Service, ICategoryService
    {
        public IEnumerable<CategoryViewModel> GetAllCategoriesNamesImages()
        {
            IEnumerable<Category> categories = this.Context.Categories;

            IEnumerable<CategoryViewModel> view =
                Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return view;
        }

        public IEnumerable<ProductViewModel> GetDetailCategory(int categoryid)
        {
            IEnumerable<Product> products = this.Context.Products.Where(p => p.Category.Id == categoryid);

            IEnumerable<ProductViewModel> view =
                Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return view;
        }
    }
}
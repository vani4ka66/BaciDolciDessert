using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Data;
using BaciDolci.Data.Interfaces;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Home;
using BaciDolci.Models.ViewModels.Product;
using PagedList;

namespace BaciDolci.App.Services
{
    public class HomeService : Service, IHomeService
    {
        public IEnumerable<NewsItemViewModel> GetAllNews(int page = 1, int count = 5)
        {
            IEnumerable<NewsItem> news = this.Context.NewsItems
               .OrderByDescending(p=> p.PublishDate)
               .Skip((page - 1) * count)
               .Take(count);

            IEnumerable<NewsItemViewModel> view =
                Mapper.Map<IEnumerable<NewsItem>, IEnumerable<NewsItemViewModel>>(news);

            return view;

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //return (view.ToPagedList(pageNumber, pageSize));
        }

        public object GetMaxPapes(int count = 5)
        {
            return ((this.Context.NewsItems.Count() + count - 1)/ count);
        }

        public object GetCurrentPage(int page = 1)
        {
            return page;
        }

        public object GetAllProducts()
        {
            return this.Context.Products;
        }

        public IEnumerable<Product> SearchProduct(string keyword)
        {
            return this.Context.Products.Where(x => x.Name.Contains(keyword));
        }

        //public object GetAllNewss(int page)
        //{
        //   return this.Context.NewsItems.OrderByDescending(p => p.PublishDate)
        //       .ToPagedList(page ?? 1, 6);

        //}


       
    }
}
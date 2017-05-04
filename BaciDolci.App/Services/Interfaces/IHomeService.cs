using System.Collections.Generic;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Home;

namespace BaciDolci.App.Services.Interfaces
{
    public interface IHomeService
    {
        IEnumerable<NewsItemViewModel> GetAllNews(int page = 1, int count = 5);
        object GetMaxPapes(int count = 5);
        object GetCurrentPage(int page = 1);
        object GetAllProducts();
        IEnumerable<Product> SearchProduct(string keyword);
    }
}
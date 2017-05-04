using System.Collections.Generic;
using BaciDolci.Models.ViewModels.Product;

namespace BaciDolci.App.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetAllCategoriesNamesImages();
        IEnumerable<ProductViewModel> GetDetailCategory(int categoryid);
    }
}
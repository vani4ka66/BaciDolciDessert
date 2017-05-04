using BaciDolci.Models.BindingModels;

namespace BaciDolci.App.Services.Interfaces
{
    public interface IAdminService
    {
        void GetAddCategory(CategoryBindingModel bind);
        CategoryBindingModel GetEditCategory(int id);
        void UpdateCategory(CategoryBindingModel bind);
        DeleteCategoryBindingModel GetDeleteCategory(int id);
        void DeleteCategory(DeleteCategoryBindingModel bind);
        void GetAddProduct(ProductBindingModel bind);
        ProductBindingModel GetEditProduct(int id);
        void UpdateProduct(ProductBindingModel bind);
        DeleteProductBindingModel GetDeleteProduct(int id);
        void DeleteProduct(DeleteProductBindingModel bind);
        object GetViewBagCategories();
        void GetAddNews(NewsBindingModel bind);
        NewsBindingModel GetEditNews(int id);
        void UpdateNews(NewsBindingModel bind);
        DeleteNewsBindingModel GetDeleteNews(int id);
        void DeleteNews(DeleteNewsBindingModel bind);
        object GetAllCategoriesId();
    }
}
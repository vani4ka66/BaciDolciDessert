using BaciDolci.Models.BindingModels;
using BaciDolci.Models.ViewModels.Product;

namespace BaciDolci.App.Services.Interfaces
{
    public interface IProductService
    {
        ProductViewModel GetDetailProduct(int productId);
        void BuyProduct(string user, BuyProductBindingModel bind);
    }
}
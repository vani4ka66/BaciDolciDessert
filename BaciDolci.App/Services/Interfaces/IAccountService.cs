using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Account;

namespace BaciDolci.App.Services.Interfaces
{
    public interface IAccountService
    {
        void CreateCustomer(ApplicationUser user, RegisterViewModel model);
        int CheckUsersCount();
    }
}
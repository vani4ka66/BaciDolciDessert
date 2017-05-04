using System.Collections.Generic;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Customer;

namespace BaciDolci.App.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerProfileViewModel> GetWinners();
        ApplicationUser GetAllCustomers();
        IEnumerable<Customer> GetCustomers();
        IEnumerable<ApplicationUser> GetAdmins(bool isAdmin);
        CustomerProfileViewModel GetMyProfile(string user);
    }
}
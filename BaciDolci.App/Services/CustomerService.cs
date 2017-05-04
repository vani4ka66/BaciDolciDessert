using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Customer;
using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;

namespace BaciDolci.App.Services
{
    public class CustomerService : Service, ICustomerService
    {
        public IEnumerable<CustomerProfileViewModel> GetWinners()
        {
            var users = this.Context.Users.Take(3);

            IEnumerable<CustomerProfileViewModel> vms = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<CustomerProfileViewModel>>(users);
            return vms;

        }


        public ApplicationUser GetAllCustomers()
        {
            //Customer customer = this.Context.Customers.FirstOrDefault();

            //CustomerProfileViewModel vm = Mapper.Map<Customer, CustomerProfileViewModel>(customer);

            ApplicationUser user = this.Context.Users.FirstOrDefault();
            return user;

        }


        public IEnumerable<Customer> GetCustomers()
        {
            return this.Context.Customers;
        }

        public IEnumerable<ApplicationUser> GetAdmins(bool isAdmin)
        {
            var admins = this.Context.Users.FirstOrDefault(x => x.Roles.Any());
            return null;

        }

        public CustomerProfileViewModel GetMyProfile(string user)
        {
            Customer customer = this.Context.Customers.FirstOrDefault(x => x.User.UserName == user);
            customer.UserName = user;
            customer.Email = user;

            CustomerProfileViewModel view = Mapper.Map<Customer, CustomerProfileViewModel>(customer);

            return view;

        }
    }
}
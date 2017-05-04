using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BaciDolci.App.Areas.Admin.Services;
using BaciDolci.App.Services.Interfaces;
using BaciDolci.Models.EntityModels;
using BaciDolci.Models.ViewModels.Account;

namespace BaciDolci.App.Services
{
    public class AccountService : Service, IAccountService
    {
        public void CreateCustomer(ApplicationUser user, RegisterViewModel model)
        {
            Customer customer = Mapper.Map<RegisterViewModel,Customer>(model);
            //Customer customer = Mapper.Map< Customer>(model);

            ApplicationUser currentUser = this.Context.Users.Find(user.Id);

            if (currentUser != null)
            {
                customer.User = currentUser;
            }

            this.Context.Customers.Add(customer);
            this.Context.SaveChanges();
        }

        public int CheckUsersCount()
        {
            return this.Context.Users.Count();
        }
    }
}
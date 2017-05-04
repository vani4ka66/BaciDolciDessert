using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaciDolci.Models.EntityModels;

namespace BaciDolci.Data.Interfaces
{
    public interface IBaciDolciContext
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<NewsItem> NewsItems { get; set; }

        int SaveChanges();
    }
}

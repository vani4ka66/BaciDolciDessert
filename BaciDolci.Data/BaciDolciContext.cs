using BaciDolci.Data.Interfaces;
using BaciDolci.Models.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaciDolci.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BaciDolciContext : IdentityDbContext<ApplicationUser>   //, IBaciDolciContext
    {
        public BaciDolciContext()
            : base("BaciDolciContext", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<NewsItem> NewsItems { get; set; }


        public static BaciDolciContext Create()
        {
            return new BaciDolciContext();
        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>()
        //        .HasMany(c => c.Products)
        //        .WithRequired(r => r.Category)
        //        .HasForeignKey(v=> v.Category.Id)
        //        .WillCascadeOnDelete(true);

        //    base.OnModelCreating(modelBuilder);
        //}
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaciDolci.Models.ViewModels.Customer
{
    public class CustomerProfileViewModel
    {
        public CustomerProfileViewModel()
        {
            this.Products = new HashSet<EntityModels.Product>();
        }

        [Required]
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string UserName { get; set; }

        public ICollection<EntityModels.Product> Products { get; set; }


    }
}

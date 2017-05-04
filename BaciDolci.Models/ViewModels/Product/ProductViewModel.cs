using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaciDolci.Models.EntityModels;

namespace BaciDolci.Models.ViewModels.Product
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        //[Display(Name = "Category_Id")]
        public int CategoryId { get; set; }

        //public Category Category { get; set; }


    }
}

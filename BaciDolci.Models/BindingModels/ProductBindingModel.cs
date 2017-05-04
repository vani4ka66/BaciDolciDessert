using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;
using BaciDolci.Models.EntityModels;

namespace BaciDolci.Models.BindingModels
{
    public class ProductBindingModel
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

        //[Required]
        //[Display(Name = "Category_Id")]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        //public ICollection<SelectListItem> Categories { get; set; }



    }
}

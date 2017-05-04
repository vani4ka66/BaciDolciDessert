using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaciDolci.Models.ViewModels.Product
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.Products = new List<ProductViewModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}

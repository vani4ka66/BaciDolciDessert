using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaciDolci.Models.EntityModels
{
    public class Product
    {
        private string name;
        private decimal price;


        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "The name can not be null");
                }

                if (value.Length <= 3 && value.Length >= 50)
                {
                    throw  new ArgumentException("Name must be between 3 and 50 symbols long");
                }

                this.name = value;
            }
        }

        [Required]
        public string Image { get; set; }

        [Required]
        public decimal Price
        {
            get { return this.price; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Your value must be a positive number.");
                }

                this.price = value;
            }
        }

        [Required]
        [Display(Name = "Category_Id")]
        public int? CategoryId { get; set; }

        public Category Category { get; set; }

    }
}

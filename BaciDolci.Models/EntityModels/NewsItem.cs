using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaciDolci.Models.EntityModels
{
    public class NewsItem
    {

        public NewsItem()
        {
            this.PublishDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        //[Required]
        [Display(Name = "Publish date")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required]
        [MinLength(20)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}

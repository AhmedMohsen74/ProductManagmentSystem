using System.ComponentModel.DataAnnotations;

namespace ProductsMS.Models.Domain
{
    public class Category
    {

        public int Id { get; set; }
        [Required]
        public string ? Name { get; set; }
    }
}

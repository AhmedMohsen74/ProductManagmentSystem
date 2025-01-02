using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsMS.Models.Domain
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Category? category { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]
        public string? CategoryName { get; set; }
    }
}

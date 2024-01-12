using System.ComponentModel.DataAnnotations;

namespace Catalogue.Server.Models
{
    public class Product
    {
        public int Id { get; set; }

        [RegularExpression("^[A-Za-z]{2}[0-9]{3}$", ErrorMessage = "Code must have 2 capital letters followed by 3 digits.")]
        public required string Code { get; set; }

        public required string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
    }
}

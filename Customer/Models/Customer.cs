using System.ComponentModel.DataAnnotations;

namespace Towergate.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [Range(0, 110)]
        public int Age { get; set; }

        [RegularExpression(@"^[0-9a-zA-Z]+$", ErrorMessage = "Post code must contain numbers and characters")]
        public string PostCode { get; set; }

        [Range(0, 2.5)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Height must be a number with up to 2 decimal places")]
        public double Height { get; set; }
    }
}

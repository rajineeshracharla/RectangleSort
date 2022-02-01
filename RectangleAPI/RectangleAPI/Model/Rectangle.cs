using System.ComponentModel.DataAnnotations;

namespace RectangleAPI.Model
{
    public class Rectangle
    {
        [Required]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "You didn't enter a decimal!")]
        public decimal Length { get; set; }

        [Required]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "You didn't enter a decimal!")]
        public decimal Breadth { get; set; }

        public decimal Area => Length * Breadth;
    }
}

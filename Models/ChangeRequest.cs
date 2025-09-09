using System.ComponentModel.DataAnnotations;

namespace ChangeCalculator.Models
{
    public class ChangeRequest
    {
        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
    }
}
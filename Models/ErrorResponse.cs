namespace ChangeCalculator.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public string[]? Errors { get; set; }
    }
}
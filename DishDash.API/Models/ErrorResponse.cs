namespace DishDash.API.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; } = "An error occurred.";
        public List<string> Errors { get; set; } = new();
    }
}

namespace Dto.Response.Error
{
    public class ErrorDetailsResponse
    {
        public int status { get; set; }
        public string title { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
    }
}

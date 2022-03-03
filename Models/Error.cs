namespace ApiPengurus.Models
{
    public class Error
    {
        public string? traceId { get; set; }
        public string? title { get; set; }
        public int status { get; set; }
        public string? message { get; set; }
    }
}
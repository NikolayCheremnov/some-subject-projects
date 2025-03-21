namespace RequestGrabberApiApp
{
    public class Request
    {
        public int Id { get; set; }
        public  DateTime ReceivedAt { get; set; }
        public string HttpMethod { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public int StatusCode { get; set; }

        public Request() { }
    }
}

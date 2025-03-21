namespace CloudDbExample
{
    // Copybook - тетрадь
    public class Copybook
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int PageCount { get; set; }
        public decimal Price { get; set; }

        public Copybook() { }
    }
}

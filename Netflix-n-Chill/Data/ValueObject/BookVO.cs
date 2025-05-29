namespace Netflix_n_Chill.Data.ValueObject
{
    public class BookVO
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

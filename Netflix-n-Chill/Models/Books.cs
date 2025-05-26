using Netflix_n_Chill.Models.Base;

namespace Netflix_n_Chill.Models
{
    public class Books : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

using Netflix_n_Chill.Data.Converter.Contract;
using Netflix_n_Chill.Data.ValueObject;
using Netflix_n_Chill.Models;

namespace Netflix_n_Chill.Data.Converter.Implementations
{
    public class BookConverter : IParser<Books, BookVO>, IParser<BookVO, Books>
    {
        public Books Parse(BookVO O)
        {
            if (O == null) return null;

            return new Books
            {
                Author = O.Author,
                Id = O.Id,
                Price = O.Price,
                ReleaseDate = O.ReleaseDate,
                Title = O.Title
            };
        }

        public List<Books> Parse(List<BookVO> origin)
        {
            return origin.Select(x => Parse(x)).ToList();
        }

        public BookVO Parse(Books O)
        {
            if (O == null) return null;

            return new BookVO
            {
                Author = O.Author,
                Id = O.Id,
                Price = O.Price,
                ReleaseDate = O.ReleaseDate,
                Title = O.Title
            };
        }

        public List<BookVO> Parse(List<Books> origin)
        {
            return origin.Select(x => Parse(x)).ToList();
        }
    }
}

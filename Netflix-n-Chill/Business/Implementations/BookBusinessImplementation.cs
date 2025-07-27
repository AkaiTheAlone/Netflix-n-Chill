using Netflix_n_Chill.Business.Abstractions;
using Netflix_n_Chill.Data.Converter.Implementations;
using Netflix_n_Chill.Data.ValueObject;
using Netflix_n_Chill.Models;
using Netflix_n_Chill.Repository.Generic;

namespace Netflix_n_Chill.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Books> rep;
        private readonly BookConverter converter;

        public BookBusinessImplementation(IRepository<Books> _rep)
        {
            rep = _rep;
            converter = new BookConverter();
        }
        public BookVO Create(BookVO book)
        {
            return converter.Parse(rep.Create(converter.Parse(book)));
        }

        public void Delete(long id)
        {
            rep.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return converter.Parse(rep.FindAll());
        }

        public BookVO FindByID(long id)
        {
            return converter.Parse(rep.FindByID(id));
        }

        public BookVO Update(BookVO Book)
        {
            return converter.Parse(rep.Update(converter.Parse(Book)));
        }
    }
}

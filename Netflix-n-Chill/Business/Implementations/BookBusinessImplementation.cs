using Netflix_n_Chill.Models;
using Netflix_n_Chill.Repository;

namespace Netflix_n_Chill.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository rep;

        public BookBusinessImplementation(IBookRepository _rep)
        {
            rep = _rep;
        }
        public Books Create(Books book)
        {
            return rep.Create(book);
        }

        public void Delete(long id)
        {
            rep.Delete(id);
        }

        public List<Books> FindAll()
        {
            return rep.FindAll();
        }

        public Books FindByID(long id)
        {
            return rep.FindByID(id);
        }

        public Books Update(Books Book)
        {
            return rep.Update(Book);
        }
    }
}

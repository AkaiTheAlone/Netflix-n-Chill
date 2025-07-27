using Netflix_n_Chill.Data.ValueObject;
using Netflix_n_Chill.Models;

namespace Netflix_n_Chill.Business.Abstractions
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO Book);
        BookVO Update(BookVO Book);
        void Delete(long id);
        BookVO FindByID(long id);
        List<BookVO> FindAll();
    }
}

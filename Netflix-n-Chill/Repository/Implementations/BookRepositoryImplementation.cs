using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Netflix_n_Chill.Models;

namespace Netflix_n_Chill.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private readonly AppDbContext context;
        public BookRepositoryImplementation(AppDbContext _context)
        {
            context = _context;
        }

        public Books Create(Books book)
        {
            context.Add(book);
            context.SaveChanges();
            return book;
        }

        public void Delete(long id)
        {
            var result = context.Books.SingleOrDefault(p => p.Id == id);

            if (result != null)
            {
                try
                {
                    context.Books.Remove(result);
                    context.SaveChanges();
                }
                catch { throw; }
            }
        }

        public bool Exists(long id)
        {
            return context.Books.Any(x => x.Id == id);
        }

        public List<Books> FindAll()
        {
            return context.Books.ToList();
        }

        public Books FindByID(long id)
        {
            return context.Books.FirstOrDefault(x => x.Id == id);
        }

        public Books Update(Books book)
        {
            context.Update(book);
            context.SaveChanges();
            return book;
        }
    }
}

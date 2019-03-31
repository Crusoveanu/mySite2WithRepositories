using Microsoft.EntityFrameworkCore;
using mySite2.Data.Interfaces;
using mySite2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite2.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {

        }

        public IEnumerable<Book> FindWithAutor(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(a => a.Author)
                .Where(predicate);
        }

        public IEnumerable<Book> FindWithAutorAndBorrower(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(a => a.Author)
                .Include(a => a.Borrower)
                .Where(predicate);
        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            return _context.Books
            .Include(a => a.Author);
        }
    }
}

using mySite2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite2.Data.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> FindWithAutor(Func<Book, bool> predicate);
        IEnumerable<Book> FindWithAutorAndBorrower(Func<Book, bool> predicate);
    }
} 

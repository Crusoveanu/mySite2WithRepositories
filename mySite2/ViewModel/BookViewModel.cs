using mySite2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite2.ViewModel
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}

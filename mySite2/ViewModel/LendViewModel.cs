using mySite2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite2.ViewModel
{
    public class LendViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}

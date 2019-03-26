using mySite2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite2.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer{ get; set; }
        public int BookCount { get; set; }
    }
}

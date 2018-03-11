using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models
{
    public class Vendor
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public IList<String> Cities { get; set; }
        public IList<String> KeyWords { get; set; }
        public IList<String> ProductCategories { get; set; }
        public Boolean IsLocal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models
{
    public class Vendor
    {
        public int ID { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public List<VendorCity> Cities { get; set; }

        [Required]
        public List<VendorKeyword> KeyWords { get; set; }

        [Required]
        public List<VendorProductCategory> ProductCategories { get; set; }

        public Boolean IsLocal { get; set; }
    }
}

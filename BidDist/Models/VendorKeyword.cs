using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models
{
    public class VendorKeyword
    {
        public int ID { get; set; }

        [Required]
        public String Keyword { get; set; }
    }
}

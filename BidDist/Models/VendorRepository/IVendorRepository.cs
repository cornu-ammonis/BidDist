using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorRepository
{
    interface IVendorRepository
    {
        IEnumerable<Vendor> ListVendorsBySearchString(String searchString);
    }
}

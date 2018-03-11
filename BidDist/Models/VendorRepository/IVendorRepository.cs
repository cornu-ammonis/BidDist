using BidDist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorRepository
{
    public interface IVendorRepository
    {
        IList<Vendor> ListVendorsBySearchString(String searchString, ApplicationUser user);
    }
}

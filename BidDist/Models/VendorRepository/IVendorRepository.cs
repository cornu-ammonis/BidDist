using BidDist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorRepository
{
    public interface IVendorRepository
    {
        IList<Vendor> ListVendorsForUserBySearchString(String searchString, ApplicationUser user);

        int AddVendorListToDatabase(List<Vendor> vendors);
    }
}

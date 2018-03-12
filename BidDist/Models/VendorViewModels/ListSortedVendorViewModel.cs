using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorViewModels
{
    public class ListSortedVendorViewModel : ListVendorViewModel
    {
        public ListSortedVendorViewModel(IList<Vendor> vendors, String searchString) : base(vendors)
        {
            List<SortedVendorViewModel> vendorViewModels = new List<SortedVendorViewModel>();

            foreach (Vendor vendor in vendors)
            {
                vendorViewModels.Add( new SortedVendorViewModel(vendor, searchString) );
            }

            vendorViewModels = vendorViewModels.OrderByDescending(vvm => vvm.SearchPoints).ToList();

            foreach (SortedVendorViewModel vvm in vendorViewModels)
            {
                VendorViewModels.Add( (VendorViewModel) vvm);
            }
        }
    }
}

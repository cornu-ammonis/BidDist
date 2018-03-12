using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorViewModels
{
    public abstract class ListVendorViewModel
    {
        public List<VendorViewModel> VendorViewModels { get; set; } = new List<VendorViewModel>();

        public ListVendorViewModel(IList<Vendor> vendors)
        {

        }
    }
}

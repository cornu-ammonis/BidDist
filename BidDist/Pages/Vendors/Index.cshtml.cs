using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BidDist.Models;
using BidDist.Models.VendorRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BidDist.Pages.Vendors
{
    public class IndexModel : PageModel
    {
        private readonly IVendorRepository _vendorRepository;

        public IndexModel(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public string CurrentFilter { get; private set; }
        public IList<Vendor> Vendors { get; set; } = new List<Vendor>();

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            if (CurrentFilter != null)
            {
                Vendors = _vendorRepository.ListVendorsBySearchString(CurrentFilter);
            }
        }
    }
}
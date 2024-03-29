using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidDist.Data;
using BidDist.Models;
using BidDist.Models.VendorRepository;
using BidDist.Models.VendorViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BidDist.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(IVendorRepository vendorRepository, UserManager<ApplicationUser> userManager)
        {
            _vendorRepository = vendorRepository;
            _userManager = userManager;
        }

        public string CurrentFilter { get; private set; }
        public List<VendorViewModel> VendorViewModels { get; set; } 

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);

            if (CurrentFilter != null)
            {
                IList<Vendor> vendors = _vendorRepository.ListVendorsForUserBySearchString(CurrentFilter, user);
                VendorViewModels = new ListSortedVendorViewModel(vendors, CurrentFilter).VendorViewModels;
            }
            else
                VendorViewModels = new ListSortedVendorViewModel(new List<Vendor>(), "").VendorViewModels;
        }

        public async Task<IActionResult> OnGetExportAsync(string searchString)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            IList<Vendor> vendors = _vendorRepository.ListVendorsForUserBySearchString(searchString, user);
            VendorViewModels = new ListSortedVendorViewModel(vendors, searchString).VendorViewModels;

            String csv = VendorsCsvGenerator.GenerateVendorCsv(VendorViewModels);

            return File(new MemoryStream(Encoding.UTF8.GetBytes(csv)), "text/csv", "exported_vendors.csv");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BidDist.Data;
using BidDist.Models;
using BidDist.Models.VendorRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BidDist.Pages.Vendors
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
        public IList<Vendor> Vendors { get; set; } = new List<Vendor>();

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);

            if (CurrentFilter != null)
            {
                Vendors = _vendorRepository.ListVendorsBySearchString(CurrentFilter, user);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BidDist.Pages.Vendors
{
    public class IndexModel : PageModel
    {
        public string CurrentFilter { get; private set; }

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BidDist.Models;
using BidDist.Models.VendorRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BidDist.Pages
{
    public class AdminModel : PageModel
    {
        [BindProperty]
        public IFormFile FileUpload { get; set; }
        public String TestString { get; set; } = "";
        private readonly IVendorRepository _vendorRepository;

        public AdminModel(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public void OnGet()
        {
          
        }
        
        public void OnPost()
        {
            if (FileUpload != null)
            {
                using (var reader = new StreamReader(FileUpload.OpenReadStream()))
                {
                    List<Vendor> vendors = VendorCsvImporter.VendorCsvToListOfVendors(reader);
                    int newAdded = _vendorRepository.AddVendorListToDatabase(vendors);
                    TestString = newAdded.ToString() + " new vendors imported to the database! (out of " + vendors.Count.ToString() + " in the file)";
                }

            }
        }
    }
}
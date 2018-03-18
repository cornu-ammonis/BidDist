using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BidDist.Pages
{
    public class AdminModel : PageModel
    {
        [BindProperty]
        public IFormFile FileUpload { get; set; }
        public String TestString { get; set; } = "no";
        public void OnGet()
        {
          
        }
        
        public void OnPost()
        {
            if (FileUpload != null)
                TestString = FileUpload.ToString();
        }
    }
}
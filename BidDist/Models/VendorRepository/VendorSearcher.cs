using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorRepository
{
    public static class VendorSearcher
    {
        public static IList<Vendor> SearchVendorsByString(IList<Vendor> vendors, String searchString)
        {
            String[] searchStrings = searchString.Split(null);
            Console.WriteLine(searchStrings[0]);

            IEnumerable<Vendor> vendor_query =
                (from v in vendors
                 where v.KeyWords.Any(k => searchStrings.Any(s => s.ToLower().Contains(k.Keyword.ToLower()) || k.Keyword.ToLower().Contains(s.ToLower())))
                 || v.ProductCategories.Any(pc => searchStrings.Any(s => s.ToLower().Contains(pc.ProductCategory.ToLower()) || pc.ProductCategory.ToLower().Contains(s.ToLower())))
                 select v
                 );
                 

            List<Vendor> resultingVendors = new List<Vendor>();
            foreach (Vendor v in vendor_query)
            {
                resultingVendors.Add(v);
            }

            return resultingVendors;
        }
    }
}

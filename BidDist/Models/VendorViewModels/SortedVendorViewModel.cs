using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorViewModels
{
    public class SortedVendorViewModel : VendorViewModel
    {
        public int SearchPoints { get; set; } = 0;

        public SortedVendorViewModel(Vendor vendor, String searchString) : base(vendor) 
        {
            String[] searchStrings = searchString.ToLower().Split();
            AddPointsForProductCategory(searchStrings, vendor.ProductCategories);
        }

        private void AddPointsForProductCategory(String [] searchStrings, List<VendorProductCategory> vpcs)
        {
            Boolean[] excludeString = new Boolean[searchStrings.Length];
            int excluded = 0;

            foreach (VendorProductCategory vpc in vpcs)
            {
                if (excluded == excludeString.Length)
                    break;

                String productCategory = vpc.ProductCategory.ToLower();

                for (int i = 0; i < searchStrings.Length; i++)
                {
                    if (!excludeString[i])
                    {
                        if ( searchStrings[i].Contains(productCategory) || productCategory.Contains(searchStrings[i]) )
                        {
                            SearchPoints += 1;
                            excludeString[i] = true;
                            excluded++;
                        }
                    }
                }
            }
        }

    }
}

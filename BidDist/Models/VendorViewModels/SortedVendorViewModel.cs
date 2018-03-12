using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorViewModels
{
    public class SortedVendorViewModel : VendorViewModel
    {
        public int SearchPoints { get; set; }

        public SortedVendorViewModel(Vendor vendor, String searchString) : base(vendor) 
        {
            String[] searchStrings = searchString.ToLower().Split();
            SearchPoints = 0;
            AddPointsForProductCategory(searchStrings, vendor.ProductCategories);
            AddPointsForKeywords(searchStrings, vendor.KeyWords);
            ProductCategories = SearchPoints.ToString();
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

        private void AddPointsForKeywords(String[] searchStrings, List<VendorKeyword> vendorKeywords)
        {
            Boolean[] excludeString = new Boolean[searchStrings.Length];
            int excluded = 0;

            foreach (VendorKeyword vendorKeyword in vendorKeywords)
            {
                if (excluded == excludeString.Length)
                    break;

                String keyword = vendorKeyword.Keyword.ToLower();

                for (int i = 0; i < searchStrings.Length; i++)
                {
                    if (!excludeString[i])
                    {
                        if (searchStrings[i].Contains(keyword) || keyword.Contains(searchStrings[i]))
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

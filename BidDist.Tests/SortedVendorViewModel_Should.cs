using System;
using Xunit;
using BidDist.Models;
using BidDist.Models.VendorViewModels;
using System.Collections.Generic;

namespace BidDist.Tests
{
    public class SortedVendorViewModel_Should
    {
        [Fact]
        public void SortedVendorViewModelGeneratesSearchPointFromKeywords()
        {
            SortedVendorViewModel svvm = new SortedVendorViewModel(generateVendorForViewModel(), "keyword");

            Assert.Equal(1, svvm.SearchPoints);
        }

        [Fact]
        public void SortedVendorViewModelGeneratesSearchPointFromProductCategory()
        {
            SortedVendorViewModel svvm = new SortedVendorViewModel(generateVendorForViewModel(), "product");

            Assert.Equal(1, svvm.SearchPoints);
        }

        [Fact]
        public void SortedVendorViewModelGeneratesSearchPointFromKeyWordsAndProductCategory()
        {
            SortedVendorViewModel svvm = new SortedVendorViewModel(generateVendorForViewModel(), "product and keyword");

            Assert.Equal(4, svvm.SearchPoints);
        }

        private Vendor generateVendorForViewModel()
        {
            var cities = new List<VendorCity>
            {
                new VendorCity {City = "Detroit"}
            };

            var keyWordsOne = new List<VendorKeyword>
            {
                new VendorKeyword { Keyword = "Keyword"},
                new VendorKeyword { Keyword = "And" },
                new VendorKeyword { Keyword = "Bolts"}
            };

            var productsOne = new List<VendorProductCategory>
            {
                new VendorProductCategory { ProductCategory = "Product"},
                new VendorProductCategory { ProductCategory = "And"},
                new VendorProductCategory {ProductCategory = "Nails"}
            };

            var vendor = new Vendor { Name = "vendor one", Email = "vendor1@demo.com", IsLocal = true, Cities = cities, KeyWords = keyWordsOne, ProductCategories = productsOne };

            return vendor;
        }
    }
}
